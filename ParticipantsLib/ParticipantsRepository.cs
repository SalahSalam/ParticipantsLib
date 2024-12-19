using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipantsLib
{
    public class ParticipantsRepository
    {
        private int _nextId = 1;
        private readonly List<OlParis2024> _participants = new();

        public ParticipantsRepository()
        {
            _participants.Add(new OlParis2024 { Id = _nextId++, Name = "Alice", Age = 25, Country = "USA" });
            _participants.Add(new OlParis2024 { Id = _nextId++, Name = "Bob", Age = 30, Country = "USA" });
            _participants.Add(new OlParis2024 { Id = _nextId++, Name = "Charlie", Age = 22, Country = "Canada" });
            _participants.Add(new OlParis2024 { Id = _nextId++, Name = "Diana", Age = 28, Country = "Australia" });
            _participants.Add(new OlParis2024 { Id = _nextId++, Name = "Eve", Age = 27, Country = "France" });
        }

        public List<OlParis2024> GetAll()
        {
            return new List<OlParis2024>(_participants);
        }

        public OlParis2024? GetById(int id)
        {
            return _participants.FirstOrDefault(p => p.Id == id);
        }
        public OlParis2024 Add(OlParis2024 participant)
        {
            participant.Validate();
            participant.Id = _nextId++;
            _participants.Add(participant);
            return participant;
        }


        public OlParis2024 Delete(int id)
        {
            OlParis2024? participant = GetById(id);
            if (participant != null)
            {
                _participants.Remove(participant);
            }
            return participant;
        }
    }
}
