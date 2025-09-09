using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Interfaces
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
