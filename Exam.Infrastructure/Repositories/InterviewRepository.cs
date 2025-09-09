using Dapper;
using Exam.Application.Interfaces;
using Exam.Domain.Entities;
using System.Data;

namespace Exam.Infrastructure.Repositories
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly IDbConnection _dbConnection;

        public InterviewRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Interview? GetById(int id)
        {
            var sql = @"
                select
                    id as Id,
                    candidateid as CandidateId,
                    vacancyid as VacancyId,
                    scheduledat as ScheduledAt,
                    result as Result,
                    notes as Notes
                from interviews
                where id = @Id";

            return _dbConnection.QuerySingleOrDefault<Interview>(sql, new { Id = id });
        }

        public List<Interview> GetAll()
        {
            var sql = @"
                select
                    id as Id,
                    candidateid as CandidateId,
                    vacancyid as VacancyId,
                    scheduledat as ScheduledAt,
                    result as Result,
                    notes as Notes
                from interviews";

            return _dbConnection.Query<Interview>(sql).ToList();
        }

        public List<(string CandidateFullName, string Result, DateTime ScheduledAt)> GetByVacancyId(int vacancyId)
        {
            var sql = @"
                select 
                    c.fullname as CandidateFullName,
                    i.result as Result,
                    i.scheduledat as ScheduledAt
                from interviews i
                join candidates c on i.candidateid = c.id
                where i.vacancyid = @VacancyId";

            return _dbConnection.Query<(string CandidateFullName, string Result, DateTime ScheduledAt)>(sql, new { VacancyId = vacancyId }).ToList();
        }

        public int Create(Interview interview)
        {
            var sql = @"
                insert into interviews(candidateid, vacancyid, scheduledat, result, notes)
                values
                    (@CandidateId, @VacancyId, @ScheduledAt, @Result, @Notes)
                returning id";

            return _dbConnection.ExecuteScalar<int>(sql, interview);
        }

        public int Update(Interview interview)
        {
            var sql = @"
                update interviews
                set
                    candidateid = @CandidateId,
                    vacancyid = @VacancyId,
                    scheduledat = @ScheduledAt,
                    result = @Result,
                    notes = @Notes
                where id = @Id";

            return _dbConnection.Execute(sql, interview);
        }

        public int Delete(int id)
        {
            var sql = @"
                delete from interviews
                where id = @Id";

            return _dbConnection.Execute(sql, new { Id = id });
        }
    }
}
