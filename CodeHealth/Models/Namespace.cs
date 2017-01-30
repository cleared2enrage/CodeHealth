using System.Collections.Generic;
using System.Xml.Serialization;

namespace CodeHealth.Models
{
    public class Namespace : Scope
    {
        [XmlArray]
        public List<Type> Types { get; set; }

        public override IEnumerable<Scope> Children => Types;
    }
}