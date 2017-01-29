using System.Collections.Generic;
using System.Xml.Serialization;

namespace CodeHealth.Models
{
    public class Member
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray]
        public List<Metric> Metrics { get; set; }
    }
}