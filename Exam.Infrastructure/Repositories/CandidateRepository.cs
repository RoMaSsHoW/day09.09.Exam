using Dapper;
using Exam.Application.Interfaces;
using Exam.Domain.Entities;
using System.Data;
using static Dapper.SqlMapper;

namespace Exam.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IDbConnection _dbConnection;

        public CandidateRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Candidate? GetById(int id)
        {
            var sql = @"
                select
                    id as Id,
                    fullname as FullName,
                    email as Email,
                    phone as Phone,
                    position as Position,
                    experienceyears as ExperienceYears,
                    expectedsalary as ExpectedSalary,
                    status as Status,
                    createdat as CreatedAt
                from candidates
                where id = @Id";

            return _dbConnection.QuerySingleOrDefault<Candidate>(sql, new { Id = id });
        }

        public List<Candidate> GetAll(string? status, decimal? salaryFrom, decimal? salaryTo, int? experienceYearsFrom)
        {
            var sql = @"
                select
                    id as Id,
                    fullname as FullName,
                    email as Email,
                    phone as Phone,
                    position as Position,
                    experienceyears as ExperienceYears,
                    expectedsalary as ExpectedSalary,
                    status as Status,
                    createdat as CreatedAt
                from candidates
                where 1 = 1";

            var parameters = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(status))
            {
                sql += " and status like @Status";
                parameters.Add("Status", $"{status}%");
            }

            if (salaryFrom != null)
            {
                sql += " and expectedsalary >= @SalaryFrom";
                parameters.Add("SalaryFrom", salaryFrom);
            }

            if (salaryTo != null)
            {
                sql += " and expectedsalary <= @SalaryTo";
                parameters.Add("SalaryTo", salaryTo);
            }

            if (experienceYearsFrom != null)
            {
                sql += " and experienceyears >= @ExperienceYearsFrom";
                parameters.Add("ExperienceYearsFrom", experienceYearsFrom);
            }

            sql += " order by id";

            return _dbConnection.Query<Candidate>(sql, parameters).ToList();
        }

        public int Create(Candidate candidate)
        {
            var sql = @"
                insert into candidates(fullname, email, phone, position, experienceyears, expectedsalary, status, createdat)
                values
                    (@FullName, @Email, @Phone, @Position, @ExperienceYears, @ExpectedSalary, @Status, @CreatedAt)
                returning id";

            return _dbConnection.ExecuteScalar<int>(sql, candidate);
        }

        public int Update(Candidate candidate)
        {
            var sql = @"
                update candidates
                set 
                    fullname = @FullName,
                    email = @Email,
                    phone = @Phone,
                    position = @Position,
                    experienceyears = @ExperienceYears,
                    expectedsalary = @ExpectedSalary,
                    status = @Status
                where id = @Id";

            return _dbConnection.Execute(sql, candidate);
        }

        public int Delete(int id)
        {
            var sql = @"
                delete from candidates 
                where id = @Id";

            return _dbConnection.Execute(sql, new { Id = id });
        }
    }
}
