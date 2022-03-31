using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Models
{
    public class UserRole
    {
        public SelectList Users { get; set; }
        public SelectList Roles { get; set; }

        public UserRole(List<ApplicationUser>users,List<IdentityRole>roles)
        {
            Users = new SelectList(users,"Id","Email");
            Roles = new SelectList(roles, "Id", "Name");
        }
    }
}
