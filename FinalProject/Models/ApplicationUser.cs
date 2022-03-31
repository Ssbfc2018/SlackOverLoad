using Microsoft.AspNetCore.Identity;

namespace FinalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Reputation { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<QuestionVotation> QuestionVotations { get; set; }
        public virtual ICollection<AnswerVotation> AnswerVotations { get; set; }

        public ApplicationUser()
        {
            Reputation = 0;
            Questions = new HashSet<Question>();
            QuestionVotations = new HashSet<QuestionVotation>();
            AnswerVotations = new HashSet<AnswerVotation>();
        }
    }
}
