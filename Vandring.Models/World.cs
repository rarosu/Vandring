using System.Collections.Generic;

namespace Vandring.Models
{
    public class World
    {
        public int WorldId { get; set; }
        public string Name { get; set; }
        public List<WorldMembership> Members { get; set; }
    }
}
