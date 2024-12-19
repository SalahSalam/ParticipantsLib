using Microsoft.AspNetCore.Mvc;
using ParticipantsLib;
using System.Collections.Generic;
using System.Linq;

namespace ParticipantsREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly ParticipantsRepository _repository;

        public ParticipantsController()
        {
            _repository = new ParticipantsRepository();
        }

        // GET: api/Participants
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var participants = _repository.GetAll();
            if (participants == null || !participants.Any())
            {
                return NotFound("No participants found.");
            }
            return Ok(participants);
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var participant = _repository.GetById(id);
            if (participant == null)
            {
                return NotFound($"Participant with id {id} not found.");
            }
            return Ok(participant);
        }

        // POST: api/Participants
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] OlParis2024 participant)
        {
            if (participant == null)
            {
                return BadRequest("Participant data is missing.");
            }

            var addedParticipant = _repository.Add(participant);
            return CreatedAtAction(nameof(Get), new { id = addedParticipant.Id }, addedParticipant);
        }

        // PUT: api/Participants/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] OlParis2024 participant)
        {
            if (participant == null)
            {
                return BadRequest("Participant data is missing.");
            }

            if (id != participant.Id)
            {
                return BadRequest("Participant id mismatch.");
            }

            var existingParticipant = _repository.GetById(id);
            if (existingParticipant == null)
            {
                return NotFound($"Participant with id {id} not found.");
            }

            _repository.Delete(id);
            _repository.Add(participant);
            return Ok(participant);
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var participant = _repository.GetById(id);
            if (participant == null)
            {
                return NotFound($"Participant with id {id} not found.");
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}