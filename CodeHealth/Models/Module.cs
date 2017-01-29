using System.Collections.Generic;
using System.Xml.Serialization;

namespace CodeHealth.Models
{
    public class Module
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string AssemblyVersion { get; set; }

        [XmlAttribute]
        public string FileVersion { get; set; }

        [XmlArray]
        public List<Metric> Metrics { get; set; }

        [XmlArray]
        public List<Namespace> Namespaces { get; set; }
    }
}