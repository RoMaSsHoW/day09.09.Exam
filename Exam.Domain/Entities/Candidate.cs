namespace Exam.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Position { get; set; }
        public int ExperienceYears { get; set; } = 0;
        public decimal? ExpectedSalary { get; set; }
        public string Status { get; set; } = "Applied";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
