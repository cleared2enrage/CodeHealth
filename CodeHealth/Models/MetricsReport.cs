using System.Collections.Generic;
using System.Xml.Serialization;

namespace CodeHealth.Models
{
    [XmlRoot("CodeMetricsReport")]
    public class MetricsReport
    {
        [XmlArray]
        public List<Target> Targets { get; set; }
    }
}