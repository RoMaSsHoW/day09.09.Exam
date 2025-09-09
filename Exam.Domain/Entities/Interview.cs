namespace Exam.Domain.Entities
{
    public class Interview
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int VacancyId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string Result { get; set; } = "NA";
        public string? Notes { get; set; }
    }
}
