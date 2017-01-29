using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CodeHealth.Models;
using System.Xml.Serialization;

namespace CodeHealth.Tests.Models
{
    [TestFixture]
    public class MetricsReportTests
    {
        private Stream _metricsFileStream;
        private XmlSerializer _serializer;

        [SetUp]
        public void SetUp()
        {
            _serializer = new XmlSerializer(typeof(MetricsReport));
            _metricsFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CodeHealth.Tests.Resources.metrics.xml");
        }

        [Test]
        public void CanDeserializeFromFile()
        {
            var metricsReport = _serializer.Deserialize(_metricsFileStream) as MetricsReport;

            Assert.NotNull(metricsReport);

            Assert.NotNull(metricsReport.Targets);
            Assert.AreEqual(1, metricsReport.Targets.Count);

            var firstTarget = metricsReport.Targets.First();

            Assert.NotNull(firstTarget.Name);
            Assert.NotNull(firstTarget.Modules);
            Assert.AreEqual(1, firstTarget.Modules.Count);

            var firstModule = firstTarget.Modules.First();

            Assert.NotNull(firstModule.Name);
            Assert.NotNull(firstModule.AssemblyVersion);
            Assert.NotNull(firstModule.FileVersion);
            Assert.NotNull(firstModule.Metrics);
            Assert.AreEqual(5, firstModule.Metrics.Count);
            Assert.NotNull(firstModule.Namespaces);
            Assert.NotZero(firstModule.Namespaces.Count);

            var moduleMetric = firstModule.Metrics.First();

            Assert.NotNull(moduleMetric.Name);
            Assert.NotNull(moduleMetric.Value);

            var firstNamespace = firstModule.Namespaces.First();

            Assert.NotNull(firstNamespace.Name);
            Assert.NotNull(firstNamespace.Metrics);
            Assert.NotZero(firstNamespace.Metrics.Count);
            Assert.NotNull(firstNamespace.Types);
            Assert.NotZero(firstNamespace.Types.Count);

            var firstType = firstNamespace.Types.First();

            Assert.NotNull(firstType.Name);
            Assert.NotNull(firstType.Metrics);
            Assert.NotZero(firstType.Metrics.Count);
            Assert.NotNull(firstType.Members);
            Assert.NotZero(firstType.Members.Count);

            var firstMember = firstType.Members.First();

            Assert.NotNull(firstMember.Name);
            Assert.NotNull(firstMember.Metrics);
            Assert.NotZero(firstMember.Metrics.Count);
        }

        [TearDown]
        public void TearDown()
        {
            if (_metricsFileStream != null)
            {
                _metricsFileStream.Close();
                _metricsFileStream.Dispose();
            }
        }
    }
}
