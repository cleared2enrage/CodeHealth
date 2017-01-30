using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CodeHealth.Models
{
    public class Type : Scope
    {
        public override IEnumerable<Scope> Children => Members;

        [XmlArray]
        public List<Member> Members { get; set; }
    }
}