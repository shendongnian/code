    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            XmlSerializer sr = new XmlSerializer(typeof(ClassToSerialize));
            var demo = new DemoChild();
            var ser = new ClassToSerialize {anotherOne = demo};
            var stream = new MemoryStream();
            sr.Serialize(stream, ser);
        }
    }
    public class ClassToSerialize
    {
        [XmlElement(Type = typeof(DemoChild))]
        public AnotherOne anotherOne;
        public ClassToSerialize()
        {
        }
    }
    public abstract class AnotherOne : IXmlSerializable
    {
        protected AnotherOne()
        {
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
        }
        public void WriteXml(XmlWriter writer)
        {
        }
    }
    public class DemoChild: AnotherOne
    {
    }
