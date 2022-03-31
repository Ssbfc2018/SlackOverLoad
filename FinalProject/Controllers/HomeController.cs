using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public HomeController(ApplicationDbContext DB,ILogger<HomeController> logger,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _db = DB;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> HomePage(string? currentPageIndex)
        {
            ViewBag.Sorting = "Most Answered";

            int page = 1;
            ViewBag.PageIndex = 1;
            if (currentPageIndex != null)
            {
                ViewBag.PageIndex = Int32.Parse(currentPageIndex);
                page = Int32.Parse(currentPageIndex); 
            }
            ViewBag.Next = ViewBag.PageIndex + 1;
            ViewBag.Prev = ViewBag.PageIndex - 1;

            ViewBag.PageSize = _db.Questions.Count() / 10 + 1;
            IQueryable<Question> currentPage = _db.Questions.Skip((page - 1) * 10);
            currentPage = currentPage.Take(page * 10).Include(q=>q.User);

            string currentUser = User.Identity.Name;
            ViewBag.ApplicationUser = await _userManager.FindByNameAsync(currentUser);

            return View(currentPage.ToList());
        }
        public async Task<IActionResult> ChangeSorting(string Switch,int PageIndex)
        {
            IQueryable<Question> currentPage;
            switch (Switch)
            {
                case "Most Answered":
                    ViewBag.PageSize = _db.Questions.Count() / 10 + 1;
                    currentPage = _db.Questions.Skip((PageIndex - 1) * 10);
                    currentPage = currentPage.Take(PageIndex * 10).Include(q => q.User);
                    currentPage =currentPage.OrderByDescending(q => q.AnswerCount);
                    ViewBag.Sorting = "Date";
                    break;
                default:
                    ViewBag.PageSize = _db.Questions.Count() / 10 + 1;
                    currentPage = _db.Questions.Skip((PageIndex - 1) * 10);
                    currentPage = currentPage.Take(PageIndex * 10).Include(q => q.User);
                    currentPage =currentPage.OrderByDescending(q => q.PublishDate);
                    ViewBag.Sorting = "Most Answered";
                    break;
            }

            string currentUser = User.Identity.Name;
            ViewBag.ApplicationUser = await _userManager.FindByNameAsync(currentUser);
            ViewBag.PageIndex = PageIndex;

            return View("HomePage", currentPage.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPage()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(string newRole)
        {
            try
            {
                await _roleManager.CreateAsync(new IdentityRole(newRole));
                _db.SaveChanges();

                string currentUser = User.Identity.Name;

                ApplicationUser awaitUser = await _userManager.FindByNameAsync(currentUser);

                if (await _roleManager.RoleExistsAsync(newRole))
                {
                    if (!await _userManager.IsInRoleAsync(awaitUser, newRole))
                    {
                        await _userManager.AddToRoleAsync(awaitUser, newRole);
                    }
                }
            }catch (Exception ex)
            {
                return RedirectToAction("Error", new {message = ex.Message});
            }

            return View();
        }
        [Authorize(Roles="Admin")]
        public IActionResult AddUserToRole()
        {
            List<ApplicationUser> users=_db.Users.ToList();
            List<IdentityRole> roles=_db.Roles.ToList();

            UserRole ur = new UserRole(users,roles);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string? userId,string? roleId)
        {
            try
            {
                if (userId != null && roleId != null)
                {
                    ApplicationUser user = await _userManager.FindByNameAsync(userId);
                    IdentityRole role = await _roleManager.FindByIdAsync(roleId);

                    if (user != null && role != null)
                    {
                        bool userAlreadyInRole = await _userManager.IsInRoleAsync(user,role.Name);

                        if (userAlreadyInRole)
                        {
                            await _userManager.AddToRoleAsync(user,role.Name);
                            _db.SaveChanges();

                            ViewBag.SuccessMessage = $"Assigned ${user.Email} as ${role.Name}";
                        }
                        else
                        {
                            ViewBag.SuccessMessage = $"${user.Email} is already in ${role.Name}";
                        }
                        List<ApplicationUser> users = _db.Users.ToList();
                        List<IdentityRole> roles = _db.Roles.ToList();

                        UserRole ur = new UserRole(users, roles);

                        return View();
                    }
                }

                return NotFound();

            }catch (Exception ex)
            {
                return RedirectToAction("Error", new { message = ex.Message });
            }
        }
        public IActionResult allQuestions()
        {
            return View(_db.Questions.Include(q=>q.User).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}