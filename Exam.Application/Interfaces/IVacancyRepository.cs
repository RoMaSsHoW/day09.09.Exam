using Exam.Domain.Entities;

namespace Exam.Application.Interfaces
{
    public interface IVacancyRepository
    {
        Vacancy? GetById(int id);
        List<Vacancy> GetAll();
        int Create(Vacancy vacancy);
        int Update(Vacancy vacancy);
        int Delete(int id);
    }
}
