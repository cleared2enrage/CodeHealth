using System.Collections.Generic;
using System.Xml.Serialization;

namespace CodeHealth.Models
{
    public class Namespace
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray]
        public List<Metric> Metrics { get; set; }

        [XmlArray]
        public List<Type> Types { get; set; }
    }
}