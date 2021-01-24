    namespace FileHelpersConsoleApplication1
    {
        public class Program
        {
            public class Record
            {
                public string Id;
                public string Name;
            }
    
            public static void Main(string[] args)
            {
                var type = typeof(Record);
    
                var defaultDelimiter = ",";
                var aName = type.Assembly.GetName();
                var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
                var mb = ab.DefineDynamicModule(aName.Name);
                var tb = mb.DefineType(type.Name + "Proxy", TypeAttributes.Public, type);
    
                var attrCtorParams = new Type[] { typeof(string) };
                var attrCtorInfo = typeof(DelimitedRecordAttribute).GetConstructor(attrCtorParams);
                var attrBuilder = new CustomAttributeBuilder(attrCtorInfo, new object[] { defaultDelimiter });
                tb.SetCustomAttribute(attrBuilder);
    
                var newType = tb.CreateType();
    
                var engine = new FileHelperAsyncEngine(newType);
                //var options = engine.Options as DelimitedRecordOptions;
                //options.Delimiter = "|"; // you can still change delimiter if you need to
    
                string src = "abc,JohnDoe";
                using (engine.BeginReadString(src))
                {
                    var enumerator = (engine as IEnumerable<object>).GetEnumerator();
                    enumerator.MoveNext();
    
                    var currentRecord = enumerator.Current as Record;
                    Assert.AreEqual("abc", currentRecord.Id);
                    Assert.AreEqual("JohnDoe", currentRecord.Name);
                }
                Console.ReadKey();
            }
        }
    }
