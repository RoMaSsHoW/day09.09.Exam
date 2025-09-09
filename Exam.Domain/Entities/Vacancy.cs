namespace Exam.Domain.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Department { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
