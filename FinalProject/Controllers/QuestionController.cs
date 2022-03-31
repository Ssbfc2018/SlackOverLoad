using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FinalProject.Controllers
{
    public class QuestionController : Controller
    {
        private ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public QuestionController(ApplicationDbContext DB, ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _db = DB;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string title, string content,string? tags)
        {
            string userName = User.Identity.Name;
            string[] tagList= new string[] {};
            if (tags != null)
            {
                tagList = tags.ToString().Split(",");
                foreach(string t in tagList)
                {
                    if (_db.Tags.FirstOrDefault(ts=>ts.Name==t) == null)
                    {
                        Tag newTag = new Tag { Name = t };
                        _db.Tags.Add(newTag);
                    }
                }
            }
            await _db.SaveChangesAsync();

            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    Question newQuestion = new Question
                    {
                        Title = title,
                        Content = content,
                        UserId = user.Id,
                        AnswerCount = 0,
                        PublishDate = DateTime.Now
                    };
                    _db.Questions.Add(newQuestion);
                    await _db.SaveChangesAsync();


                    if (tagList.Length > 0)
                    {
                        foreach(string tl in tagList)
                        {
                            QuestionTag qt = new QuestionTag();
                            Tag t = _db.Tags.FirstOrDefault(t => t.Name == tl);

                            qt.QuestionId = newQuestion.Id;
                            qt.TagId= t.Id;

                            _db.QuestionsTags.Add(qt);
                            await _db.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return RedirectToAction("HomePage", "Home");
        }

        public async Task<IActionResult> Details(int questionId)
        {
            string userName = User.Identity.Name;
            ApplicationUser user = _db.Users.FirstOrDefault(u=>u.UserName==userName);

            Question question = _db.Questions
                .Include(q => q.User)
                .Include(q => q.Comments).ThenInclude(c => c.User)
                .Include(q => q.Answers).ThenInclude(a => a.Comments).Include(a => a.Votations).ThenInclude(c => c.User)
                .Include(q => q.Tags).ThenInclude(qt => qt.Tag)
                .Include(q => q.Votations)
                .FirstOrDefault(q => q.Id == questionId);

            ViewBag.userId = user.Id;
            ViewBag.IsVoting = true;
            if (question.UserId != user.Id && question.Votations.FirstOrDefault(v => v.UserId == user.Id) == null)
            {
               ViewBag.IsVoting = false;
            }

            return View(question);
        }
        public async Task<IActionResult> Voting(string QorA, int id,bool upDown)
        {
            int questionId=0;
            string userName = User.Identity.Name;
            ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(au => au.UserName == userName);
            string userId = user.Id;
            Question question;
            try
            {
                if (QorA == "q")
                {
                    QuestionVotation qv = new QuestionVotation()
                    {
                        QuestionId = id,
                        UserId = userId,
                        UpOrDown = upDown
                    };
                    _db.QuestionsVotations.Add(qv);
                    await _db.SaveChangesAsync();
                    questionId = id;
                }
                else
                {
                    Answer answer = _db.Answers.Include(a => a.Question).FirstOrDefault(a => a.Id == id);
                    AnswerVotation av = new AnswerVotation()
                    {
                        AnswerId = id,
                        UserId = userId,
                        UpOrDown = upDown
                    };
                    _db.AnswersVotations.Add(av);
                    await _db.SaveChangesAsync();
                    questionId = answer.Question.Id;
                }

                question = _db.Questions
                .Include(q => q.User)
                .Include(q => q.Comments)
                .Include(q => q.Answers).ThenInclude(a => a.Comments).ThenInclude(c => c.User)
                .Include(q => q.Tags).ThenInclude(qt => qt.Tag)
                .Include(q => q.Votations)
                .FirstOrDefault(q => q.Id == questionId);

                if (upDown)
                {
                    question.User.Reputation += 5;
                }
                else
                {
                    question.User.Reputation -= 5;
                }

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return RedirectToAction("Details",new { questionId = questionId });
        }

        public IActionResult TagDetail(int id)
        {
            List<QuestionTag> qt = _db.QuestionsTags.Where(questionTags => questionTags.TagId == id).ToList();

            return View(qt);
        }

        public IActionResult CreateAnswer(int questionId)
        {
            ViewBag.questionId = questionId;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnswer(int questionId, string content)
        {
            string userName = User.Identity.Name;
            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    Answer newAnswer = new Answer
                    {
                        QuestionId = questionId,
                        UserId = user.Id,
                        Content = content
                    };
                    _db.Answers.Add(newAnswer);

                    _db.Questions.FirstOrDefault(q => q.Id == questionId).AnswerCount++;

                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return RedirectToAction("Details", new { questionId = questionId });
        }
        public async Task<IActionResult> SetCorrectAnswer(int qid,int sid)
        {
            Question q = _db.Questions.FirstOrDefault(tq => tq.Id == qid);
            q.CorrectAnswerId = sid;
            await _db.SaveChangesAsync();

            return RedirectToAction("Details",qid);
        }

        public IActionResult Comment(string QorA, int id)
        {
            ViewBag.QorA = QorA;
            ViewBag.id = id;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Comment(string QorA,int id,string content)
        {
            string userName = User.Identity.Name;
            int questionId=0;
            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(User);
             
                if (user != null)
                {
                    Comment newComment;
                    if (QorA == "q")
                    {
                        newComment = new Comment
                        {
                            QuestionId = id,
                            UserId = user.Id,
                            Content = content
                        };
                        questionId = id;
                    }else
                    {
                        newComment = new Comment
                        {
                            AnswerId = id,
                            UserId = user.Id,
                            Content = content
                        };
                        questionId = _db.Answers.FirstOrDefault(a => a.Id == id).QuestionId.Value;
                    }

                    _db.Comments.Add(newComment);

                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            Question question = _db.Questions
                .Include(q => q.User)
                .Include(q => q.Comments)
                .Include(q => q.Answers).ThenInclude(a => a.Comments).ThenInclude(c => c.User)
                .Include(q => q.Tags).ThenInclude(qt => qt.Tag)
                .Include(q => q.Votations)
                .FirstOrDefault(q => q.Id == questionId);

            return RedirectToAction("Details", new { questionId=questionId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDoubleCheck(int questionId)
        {
            Question question = _db.Questions
                .Include(q => q.User)
                .FirstOrDefault(q => q.Id == questionId);

            return View(question);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int questionId)
        {
            Question deleteQuestion = _db.Questions.FirstOrDefault(q=>q.Id==questionId);

            Answer deleteAnswer = _db.Answers.FirstOrDefault(a => a.QuestionId == questionId);
            Comment deleteComment;
            while (deleteAnswer != null)
            {
                deleteComment = _db.Comments.FirstOrDefault(c => c.AnswerId == deleteAnswer.Id);
                while (deleteComment != null)
                {
                    _db.Comments.Remove(deleteComment);
                    await _db.SaveChangesAsync();
                    deleteComment = _db.Comments.FirstOrDefault(c => c.AnswerId == deleteAnswer.Id);
                }
                AnswerVotation deleteAnswerVotation = _db.AnswersVotations.FirstOrDefault(a => a.AnswerId == deleteAnswer.Id);
                while (deleteAnswerVotation !=null)
                {
                    _db.AnswersVotations.Remove(deleteAnswerVotation);
                    await _db.SaveChangesAsync();
                    deleteAnswerVotation = _db.AnswersVotations.FirstOrDefault(a => a.AnswerId == deleteAnswer.Id);
                }
                _db.Answers.Remove(deleteAnswer);
                await _db.SaveChangesAsync();
                deleteAnswer = _db.Answers.FirstOrDefault(a => a.QuestionId == questionId);
            }

            deleteComment = _db.Comments.FirstOrDefault(c => c.QuestionId == questionId);
            while (deleteComment != null)
            {
                _db.Comments.Remove(deleteComment);
                await _db.SaveChangesAsync();
                deleteComment = _db.Comments.FirstOrDefault(c => c.QuestionId == questionId);
            }
            QuestionVotation deleteQuestionVotation = _db.QuestionsVotations.FirstOrDefault(a => a.QuestionId == questionId);
            while (deleteQuestionVotation != null)
            {
                _db.QuestionsVotations.Remove(deleteQuestionVotation);
                await _db.SaveChangesAsync();
                deleteQuestionVotation = _db.QuestionsVotations.FirstOrDefault(av => av.QuestionId == questionId);
            }

            _db.Questions.Remove(deleteQuestion);
            await _db.SaveChangesAsync();

            return RedirectToAction("allQuestions", "Home");
        }
    }
}
