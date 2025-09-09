using Exam.Application.Interfaces;
using Exam.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateRepository _repository;

        public CandidatesController(ICandidateRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Candidate> GetById(int id)
        {
            var candidate = _repository.GetById(id);
            if (candidate == null) return NotFound();
            return Ok(candidate);
        }

        [HttpGet]
        public ActionResult<List<Candidate>> GetAll(
            [FromQuery] string? status,
            [FromQuery] decimal? salaryFrom,
            [FromQuery] decimal? salaryTo,
            [FromQuery] int? experienceYearsFrom)
        {
            var candidates = _repository.GetAll(status, salaryFrom, salaryTo, experienceYearsFrom);
            return Ok(candidates);
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody] Candidate candidate)
        {
            var id = _repository.Create(candidate);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Candidate candidate)
        {
            if (id != candidate.Id) return BadRequest("Mismatched Id");

            var rows = _repository.Update(candidate);
            if (rows == 0) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var rows = _repository.Delete(id);
            if (rows == 0) return NotFound();

            return NoContent();
        }
    }
}
