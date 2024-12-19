using System.ComponentModel.DataAnnotations;

namespace ParticipantsLib
{
    public class OlParis2024
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int Age { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"Participant ID: {Id}, Name: {Name}, Age: {Age}, Country: {Country}";
        }

        public void ValidateName()
        {
            if (Name.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Name must be at least 2 characters long.");
            }
        }

        public void ValidateAge()
        {
            if (Age < 12)
            {
                throw new ArgumentOutOfRangeException("Participants must have a age");

            }
        }

        public void ValidatCountry()
        {
            if (Country.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Participants must have a age");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateAge();
            ValidatCountry();
        }
    }
}