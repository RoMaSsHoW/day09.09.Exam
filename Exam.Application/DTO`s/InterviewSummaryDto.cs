namespace Exam.Application.DTO_s
{
    public class InterviewSummaryDto
    {
        public string CandidateFullName { get; set; } = null!;
        public string Result { get; set; } = null!;
        public DateTime ScheduledAt { get; set; }
    }
}
