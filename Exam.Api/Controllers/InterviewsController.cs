using Exam.Application.DTO_s;
using Exam.Application.Interfaces;
using Exam.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewRepository _repository;

        public InterviewsController(IInterviewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Interview> GetById(int id)
        {
            var interview = _repository.GetById(id);
            if (interview == null) return NotFound();
            return Ok(interview);
        }

        [HttpGet]
        public ActionResult<List<Interview>> GetAll()
        {
            var interviews = _repository.GetAll();
            return Ok(interviews);
        }

        [HttpGet("by-vacancy/{vacancyId}")]
        public ActionResult<List<InterviewSummaryDto>> GetByVacancyId(int vacancyId)
        {
            var result = _repository.GetByVacancyId(vacancyId);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Interview> Create(Interview interview)
        {
            var id = _repository.Create(interview);
            return CreatedAtAction(nameof(GetById), new { id }, interview);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Interview interview)
        {
            if (id != interview.Id) return BadRequest("Mismatched Id");

            var rows = _repository.Update(interview);
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
