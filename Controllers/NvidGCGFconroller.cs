using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using admLab1.Models;
using admLab1.IStorage;

namespace admLab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab1Controller : ControllerBase
    {
        private static IStorage<NvidiaGraphicsCardsGF> _videoCardList = new videoCardList();

        [HttpGet]
        public ActionResult<IEnumerable<NvidiaGraphicsCardsGF>> Get()
        {
            return Ok(_videoCardList.All);
        }

        [HttpGet("{id}")]
        public ActionResult<NvidiaGraphicsCardsGF> Get(Guid id)
        {
            if (_videoCardList.Has(id)) return NotFound("No such");

            return Ok(_videoCardList[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NvidiaGraphicsCardsGF value)
        {
            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            _videoCardList.Add(value);

            return Ok($"{value.ToString()} has been added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] NvidiaGraphicsCardsGF value)
        {
            if (_videoCardList.Has(id)) return NotFound("No such");

            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var previousValue = _videoCardList[id];
            _videoCardList[id] = value;

            return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_videoCardList.Has(id)) return NotFound("No such");

            var valueToRemove = _videoCardList[id];
            _videoCardList.RemoveAt(id);

            return Ok($"{valueToRemove.ToString()} has been removed");
        }


    }
}