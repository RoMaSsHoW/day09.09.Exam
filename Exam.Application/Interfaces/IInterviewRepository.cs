using Exam.Application.DTO_s;
using Exam.Domain.Entities;

namespace Exam.Application.Interfaces
{
    public interface IInterviewRepository
    {
        Interview? GetById(int id);
        List<Interview> GetAll();
        List<InterviewSummaryDto> GetByVacancyId(int vacancyId);
        int Create(Interview interview);
        int Update(Interview interview);
        int Delete(int id);
    }
}
