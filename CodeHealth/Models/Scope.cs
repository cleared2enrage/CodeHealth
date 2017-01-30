using System.Collections.Generic;
using System.Xml.Serialization;

namespace CodeHealth.Models
{
    public abstract class Scope
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray]
        public List<Metric> Metrics { get; set; }

        [XmlIgnore]
        public abstract IEnumerable<Scope> Children { get; }
    }
}