using Exam.Domain.Entities;
using Exam.Domain.Interfaces;
using System.Data;

namespace Exam.Infrastructure.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly IDbConnection _dbConnection;

        public VacancyRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Vacancy? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vacancy> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(Vacancy vacancy)
        {
            throw new NotImplementedException();
        }

        public int Update(Vacancy vacancy)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
