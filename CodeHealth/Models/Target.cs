using System.Collections.Generic;
using System.Xml.Serialization;

namespace CodeHealth.Models
{
    public class Target
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray]
        public List<Module> Modules { get; set; }
    }
}