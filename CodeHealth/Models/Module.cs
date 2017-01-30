using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CodeHealth.Models
{
    public class Module : Scope
    {
        [XmlAttribute]
        public string AssemblyVersion { get; set; }

        [XmlAttribute]
        public string FileVersion { get; set; }

        [XmlArray]
        public List<Namespace> Namespaces { get; set; }

        public override IEnumerable<Scope> Children => Namespaces;
    }
}