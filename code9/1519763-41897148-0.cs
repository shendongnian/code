        [DataContract]
        public class Base
        {
            [DataMember]
            string BaseProperty { get; set; }
            public void SetBase(string val)
            {
                BaseProperty = val;
            }
        }
        public class Derived : Base
        {
            public Derived()
            {
                SetBase("TestWorks");
            }
            string DerivedProperty { get; set; }
        }
        static void Main(string[] args)
        {
            var obj = new Derived();
            Base baseObject = GetBaseObject<Base, Derived>(obj);
            var baseSerializer = new DataContractSerializer(typeof(Base));
            using (var fileStream = File.OpenWrite("file"))
            using (var writer = XmlDictionaryWriter.CreateBinaryWriter(fileStream))
            {
                baseSerializer.WriteObject(writer, baseObject);
            }
            using (var fileStream = File.OpenRead("file"))
            using (var reader = XmlDictionaryReader.CreateBinaryReader(fileStream, new XmlDictionaryReaderQuotas()))
            {
                var deserialized = (Base)baseSerializer.ReadObject(reader);
            }
        }
        public static TBase GetBaseObject<TBase, T>(T obj) where TBase : new() where T : TBase
        {
            TBase bObj = new TBase();
            var bProps = bObj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (var bProp in bProps)
            {
                bProp.SetValue(bObj,
                    obj.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                    .First(p => p.Name == bProp.Name).GetValue(obj));
            }
            
            return bObj;
        }
