    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace UnitTestProject1 {
    
        [DataContract(Name = "Savefile", Namespace = "")]
        public class Savefile {
            [DataMember(Name = "Characters", Order = 0)]
            public Characters Characters { get; private set; }
    
            [DataMember(Name = "ItemPool", Order = 1)]
            public Items ItemPool { get; private set; }
    
        }
    
        [CollectionDataContract(Name = "Characters", ItemName = "Character", Namespace = "")]
        public class Characters : List<Character> {
    
        }
    
        public class Character {
            public string Weapon { get; set; }
            internal void Initialize() {
                throw new NotImplementedException();
            }
        }
    
        [CollectionDataContract(Name = "ItemPool", ItemName = "Item", Namespace = "")]
        public class Items : List<int> {
            public int value { get; set; }
        }
    
        [TestClass]
        public class UnitTestSerialization {
            [TestMethod]
            public void TestMethod1() {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Savefile));
                FileStream stream = new FileStream("SaveFile2.xml", FileMode.Open);
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
    
                Savefile _currentSave = (Savefile)serializer.ReadObject(reader);
                Assert.IsNotNull(_currentSave);
    
    
                stream.Close();
            }
        }
    }
