namespace FinalProject.Models
{
    public class QuestionVotation
    {
        public int Id { get; set; }

        public int? QuestionId { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public bool UpOrDown { get; set; }
    }
}
