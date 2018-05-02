using Microsoft.AspNet.Identity.EntityFramework;

namespace BooksAPI.Core
{
    public class RedUserStore : UserStore<IdentityUser>
    {
        public RedUserStore() : base(new RedContext())
        {
        }
    }
}