using System.Collections.Generic;

namespace CodeHealth.Models
{
    public class Member : Scope
    {
        public override IEnumerable<Scope> Children => new List<Scope>();
    }
}