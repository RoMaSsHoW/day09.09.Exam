using Dapper;
using Exam.Application.Interfaces;
using Exam.Domain.Entities;
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
            var sql = @"
                select
                    id as Id,
                    title as Title,
                    department as Department,
                    minsalary as MinSalary,
                    maxsalary as MaxSalary, 
                    isactive as IsActive,
                    createdat as CreatedAt
                from vacancies
                where id = @Id";

            return _dbConnection.QuerySingleOrDefault<Vacancy>(sql, new { Id = id });
        }

        public List<Vacancy> GetAll()
        {
            var sql = @"
                select
                    id as Id,
                    title as Title,
                    department as Department,
                    minsalary as MinSalary,
                    maxsalary as MaxSalary, 
                    isactive as IsActive,
                    createdat as CreatedAt
                from vacancies";

            return _dbConnection.Query<Vacancy>(sql).ToList();
        }

        public int Create(Vacancy vacancy)
        {
            var sql = @"
                insert into vacancies(title, department, minsalary, maxsalary, isactive, createdat)
                values
                    (@Title, @Department, @MinSalary, @MaxSalary, @IsActive, @CreatedAt)
                returning id";

            return _dbConnection.ExecuteScalar<int>(sql, vacancy);
        }

        public int Update(Vacancy vacancy)
        {
            var sql = @"
                update vacancies
                set
                    title = @Title,
                    department = @Department,
                    minsalary = @MinSalary,
                    maxsalary = @MaxSalary,
                    isactive = @IsActive
                where id = @Id";

            return _dbConnection.Execute(sql, vacancy);
        }

        public int Delete(int id)
        {
            var sql = @"
                delete from vacancies 
                where id = @Id";

            return _dbConnection.Execute(sql, new { Id = id });
        }
    }
}
