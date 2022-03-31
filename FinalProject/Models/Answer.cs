namespace FinalProject.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public virtual Question? Question { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<AnswerVotation> Votations { get; set; }

        public Answer()
        {
            Comments = new List<Comment>();
            Votations = new HashSet<AnswerVotation>();
        }
    }
}
