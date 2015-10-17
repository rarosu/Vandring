using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vandring.Models
{
    public enum WorldMembershipType
    {
        Owner,
        Member
    }

    public class WorldMembership
    {
        public int WorldMembershipId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int WorldId { get; set; }
        public World World { get; set; }
        public WorldMembershipType MembershipType { get; set; }
    }
}
