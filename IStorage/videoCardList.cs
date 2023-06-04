using System;
using System.Collections.Generic;
using System.Linq;
using admLab1.IStorage;
using admLab1.Models;

namespace admLab1.IStorage
{
    public class videoCardList : IStorage<NvidiaGraphicsCardsGF>
    {
        private object _sync = new object();
        private List<NvidiaGraphicsCardsGF> _videoCardList = new List<NvidiaGraphicsCardsGF>();
        public NvidiaGraphicsCardsGF this[Guid id]
        {
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectVideoCardException($"No LabData with id {id}");

                    return _videoCardList.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectVideoCardException("Cannot request LabData with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _videoCardList.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<NvidiaGraphicsCardsGF> All => _videoCardList.Select(x => x).ToList();

        public void Add(NvidiaGraphicsCardsGF value)
        {
            if (value.Id != Guid.Empty) throw new IncorrectVideoCardException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _videoCardList.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _videoCardList.RemoveAll(x => x.Id == id);
            }
        }
    }
}