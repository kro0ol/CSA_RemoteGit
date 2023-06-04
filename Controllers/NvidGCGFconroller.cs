using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using admLab1.Models;

namespace admLab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab1Controller : ControllerBase
    {
        private static List<NvidiaGraphicsCardsGF> _videoCardList = new List<NvidiaGraphicsCardsGF>();

        [HttpGet]
        public ActionResult<IEnumerable<NvidiaGraphicsCardsGF>> Get()
        {
            return _videoCardList;
        }

        [HttpGet("{id}")]
        public ActionResult<NvidiaGraphicsCardsGF> Get(int id)
        {
            if (_videoCardList.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            return _videoCardList[id];
        }

        [HttpPost]
        public void Post([FromBody] NvidiaGraphicsCardsGF value)
        {
            _videoCardList.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NvidiaGraphicsCardsGF value)
        {
            if (_videoCardList.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _videoCardList[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_videoCardList.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _videoCardList.RemoveAt(id);
        }
    }
}