using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Interfaces
{
    public interface ICandidateRepository
    {
        Candidate? GetById(int id);
        List<Candidate> GetAll(string? status, decimal? salaryFrom, decimal? salaryTo, int? experienceYearsFrom);
        int Create(Candidate candidate);
        int Update(Candidate candidate);
        int Delete(int id);
    }
}
