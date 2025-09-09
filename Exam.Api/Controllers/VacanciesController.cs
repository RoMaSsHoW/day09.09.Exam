using Exam.Application.Interfaces;
using Exam.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacanciesController : ControllerBase
    {
        private readonly IVacancyRepository _repository;

        public VacanciesController(IVacancyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Vacancy> GetById(int id)
        {
            var vacancy = _repository.GetById(id);
            if (vacancy == null) return NotFound();
            return Ok(vacancy);
        }

        [HttpGet]
        public ActionResult<List<Vacancy>> GetAll()
        {
            var vacancies = _repository.GetAll();
            return Ok(vacancies);
        }

        [HttpPost]
        public ActionResult<Vacancy> Create(Vacancy vacancy)
        {
            var id = _repository.Create(vacancy);
            return CreatedAtAction(nameof(GetById), new { id }, vacancy);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Vacancy vacancy)
        {
            if (id != vacancy.Id) return BadRequest("Mismatched Id");

            var rows = _repository.Update(vacancy);
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
