using System.Xml.Serialization;

namespace CodeHealth.Models
{
    public class Metric
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Value { get; set; }
    }
}