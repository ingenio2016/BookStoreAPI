using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BooksAPI.Core
{
    public class RedUserManager : UserManager<IdentityUser>
    {
        public RedUserManager() : base(new RedUserStore())
        {
        }
    }
}