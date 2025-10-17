using System.Text;
using System.Xml;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using SepaWriter.Utils;

namespace SepaWriter.Test.Utils
{
    [TestFixture]
    public class XmlElementExtensionTest
    {
        private const string name = "sample";
        private const string name2 = "sample2";
        private const string name3 = "sample3";
        private const decimal value = 12.5m;

        public XmlElement Prepare()
        {
            var document = new XmlDocument();
            document.AppendChild(document.CreateXmlDeclaration("1.0", Encoding.UTF8.BodyName, "yes"));
            return (XmlElement) document.AppendChild(document.CreateElement("Document"));
        }

        [Test]
        public void ShouldAddMultipleOrderedNewElement()
        {
            var element = Prepare();
            var el = element.NewElement(name);
            var el2 = element.NewElement(name2);
            var el3 = element.NewElement(name3);
            ClassicAssert.True(element.HasChildNodes);
            ClassicAssert.AreEqual(3, element.ChildNodes.Count);
            ClassicAssert.AreEqual(el, element.FirstChild);
            ClassicAssert.AreEqual(el2, element.ChildNodes[1]);
            ClassicAssert.AreEqual(el3, element.LastChild);
        }

        [Test]
        public void ShouldAddNewElementWithAValue()
        {
            var element = Prepare();
            var el = element.NewElement(name, value);
            ClassicAssert.AreEqual(name, el.Name);
            ClassicAssert.AreEqual(value.ToString(), el.InnerText);
            ClassicAssert.True(element.HasChildNodes);
            ClassicAssert.AreEqual(1, element.ChildNodes.Count);
        }

        [Test]
        public void ShouldAddNewElementWithoutValue()
        {
            var element = Prepare();
            var el = element.NewElement(name);
            ClassicAssert.AreEqual(name, el.Name);
            ClassicAssert.IsEmpty(el.InnerText);
            ClassicAssert.True(element.HasChildNodes);
            ClassicAssert.AreEqual(1, element.ChildNodes.Count);
        }

        [Test]
        public void ShouldAddNewElementExplicitlyWithoutValue()
        {
            var element = Prepare();
            var el = element.NewElement(name, null);
            ClassicAssert.AreEqual(name, el.Name);
            ClassicAssert.IsEmpty(el.InnerText);
            ClassicAssert.True(element.HasChildNodes);
            ClassicAssert.AreEqual(1, element.ChildNodes.Count);
        }
    }
}