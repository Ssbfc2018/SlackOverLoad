namespace FinalProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public virtual Question? CommentToQuestion { get; set; } = null!;
        public int? AnswerId { get; set; }
        public virtual Answer? CommentToAnswer { get; set; } = null!;
        public int? CommentId { get; set; }
        public virtual Comment? CommentToComment { get; set; } = null!;
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Content { get; set; }
    }
}
