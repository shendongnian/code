    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace UnitTestProject1 {
         
        [XmlRootAttribute("Savefile")]
        public class Savefile {
            [XmlArray("Characters")]
            public List<Character> characters { get; set; }
    
            [XmlArray("ItemPool")]
            public List<Item> itemPool { get; set; }
    
            public void Initialize() {
                foreach (Character c in characters)
                    c.Initialize();
    
                //ItemPool.Load(itemPool.ToArray());
            }
            public Savefile() {
                itemPool = new List<Item>();
                characters = new List<Character>();
            }
        }
    
        public class Character {
            internal void Initialize() {
                throw new NotImplementedException();
            }
        }
        public class Item {
            public int value { get; set; }
        }
    
        [TestClass]
        public class UnitTestSerialization {
            [TestMethod]
            public void TestMethod1() {
                //DataContractSerializer serializer = new DataContractSerializer(typeof(Savefile));
                FileStream stream = new FileStream("SaveFile.xml", FileMode.Open, FileAccess.Read);
    
                //var _currentSave = serializer.ReadObject(stream) as Savefile;
                //Assert.IsNotNull(_currentSave);
    
                XmlSerializer serializer2 = new XmlSerializer(typeof(Savefile));
                var newItem = (Savefile)serializer2.Deserialize(stream);
                Assert.IsNotNull(newItem);
    
                stream.Close();
            }
        }
    }
