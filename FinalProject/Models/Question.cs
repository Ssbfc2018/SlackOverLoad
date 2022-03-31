namespace FinalProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int? CorrectAnswerId { get; set; } = null!;
        public int? AnswerCount { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<QuestionVotation> Votations { get; set; }
        public virtual ICollection<QuestionTag> Tags { get; set; }

        public DateTime PublishDate { get; set; }

        public Question()
        {
            Comments = new List<Comment>();
            Answers = new HashSet<Answer>();
            Votations = new HashSet<QuestionVotation>();
            Tags = new HashSet<QuestionTag>();
        }
    }
}
