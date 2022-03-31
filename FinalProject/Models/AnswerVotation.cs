namespace FinalProject.Models
{
    public class AnswerVotation
    {
        public int Id { get; set; }

        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

        public string? UserId { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;

        public bool UpOrDown { get; set; }
    }
}
