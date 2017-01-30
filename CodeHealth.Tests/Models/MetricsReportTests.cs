using CodeHealth.Models;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Reflection;
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
            AssertMetricsReport(metricsReport);
        }

        private void AssertMetricsReport(MetricsReport metricsReport)
        {
            Assert.NotNull(metricsReport.Targets);
            Assert.IsTrue(metricsReport.Targets.Any());

            AssertTarget(metricsReport.Targets.First());
        }

        private void AssertTarget(Target target)
        {
            Assert.NotNull(target.Name);
            Assert.NotNull(target.Modules);
            Assert.IsTrue(target.Modules.Any());

            AssertModule(target.Modules.First());
        }

        private void AssertModule(CodeHealth.Models.Module module)
        {
            AssertScope(module, true);
            AssertNamespace(module.Namespaces.First());
        }

        private void AssertNamespace(Namespace @namespace)
        {
            AssertScope(@namespace, true);
            AssertType(@namespace.Types.First());
        }

        private void AssertType(Type type)
        {
            AssertScope(type, true);
            AssertScope(type.Members.First());
        }

        private void AssertScope(Scope scope, bool assertChildren = false)
        {
            Assert.NotNull(scope.Name);
            Assert.NotNull(scope.Metrics);
            Assert.IsTrue(scope.Metrics.Any());
            var moduleMetric = scope.Metrics.First();
            Assert.NotNull(moduleMetric.Name);
            Assert.NotNull(moduleMetric.Value);

            if (assertChildren)
            {
                Assert.NotNull(scope.Children);
                Assert.IsTrue(scope.Children.Any());
            }
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
