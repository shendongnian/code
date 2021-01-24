    class Program
    {
        static void Main(string[] args)
        {
            new TestClass().Test();
        }
    }
    class TestClass
    {
        public virtual void Test()
        {
            // new project object
            var project1 = new Project()
            {
                Data = new List<ModuleData>()
                {
                    new AData() { A = "A" },
                    new BData() { B = "B" },
                    new CData() { C = "C" }
                }
            };
            // serialization; make CData explicitly known to simulate presence of "module C"
            var extraTypes = new[] { typeof(CData) };
            var extraTypesDummy = new[] { typeof(Dummies.CData) };
            var xml = project1.SerializeXml(extraTypes);
            ConsoleAndDebug.WriteLine(xml);
            // Demonstrate that the XML can be deserialized with the dummy CData type.
            TestDeserialize(project1, xml, extraTypesDummy);
            // Demonstrate that the XML can be deserialized with the real CData type.
            TestDeserialize(project1, xml, extraTypes);
            try
            {
                // Demonstrate that the XML cannot be deserialized without either the dummy or real type.
                TestDeserialize(project1, xml, new Type[0]);
                Assert.IsTrue(false);
            }
            catch (AssertionFailedException ex)
            {
                Console.WriteLine("Caught unexpected exception: ");
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                ConsoleAndDebug.WriteLine(string.Format("Caught expected exception: {0}", ex.Message));
            }
        }
        public void TestDeserialize<TProject>(TProject project, string xml, Type[] extraTypes)
        {
            TestDeserialize<TProject>(xml, extraTypes);
        }
        public void TestDeserialize<TProject>(string xml, Type[] extraTypes)
        {
            var project2 = xml.DeserializeXml<TProject>(extraTypes);
            var xml2 = project2.SerializeXml(extraTypes);
            
            ConsoleAndDebug.WriteLine(xml2);
            // Assert that the incoming and re-serialized XML are equivalent (no data was lost).
            Assert.IsTrue(XNode.DeepEquals(XElement.Parse(xml), XElement.Parse(xml2)));
        }
    }
    public static partial class DataContractSerializerHelper
    {
        public static string SerializeXml<T>(this T obj, Type [] extraTypes)
        {
            return obj.SerializeXml(new DataContractSerializer(obj == null ? typeof(T) : obj.GetType(), extraTypes));
        }
        public static string SerializeXml<T>(this T obj, DataContractSerializer serializer)
        {
            serializer = serializer ?? new DataContractSerializer(obj == null ? typeof(T) : obj.GetType());
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings { Indent = true };
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.WriteObject(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
        public static T DeserializeXml<T>(this string xml, Type[] extraTypes)
        {
            return xml.DeserializeXml<T>(new DataContractSerializer(typeof(T), extraTypes));
        }
        public static T DeserializeXml<T>(this string xml, DataContractSerializer serializer)
        {
            using (var textReader = new StringReader(xml ?? ""))
            using (var xmlReader = XmlReader.Create(textReader))
            {
                return (T)(serializer ?? new DataContractSerializer(typeof(T))).ReadObject(xmlReader);
            }
        }
    }
    public static class ConsoleAndDebug
    {
        public static void WriteLine(object s)
        {
            Console.WriteLine(s);
            Debug.WriteLine(s);
        }
    }
    public class AssertionFailedException : System.Exception
    {
        public AssertionFailedException() : base() { }
        public AssertionFailedException(string s) : base(s) { }
    }
    public static class Assert
    {
        public static void IsTrue(bool value)
        {
            if (value == false)
                throw new AssertionFailedException("failed");
        }
    }
