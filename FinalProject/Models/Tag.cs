namespace FinalProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<QuestionTag> Questions { get; set; }

        public Tag()
        {
            Questions = new List<QuestionTag>();
        }
    }
}
