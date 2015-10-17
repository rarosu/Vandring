using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Vandring.Models
{
    public class User : IdentityUser
    {
        public List<WorldMembership> Memberships { get; set; }
    }
}
