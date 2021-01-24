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
            [XmlElement("Characters")]
            public List<Character> characters { get; set; }
    
            [XmlElement("ItemPool")]
            public List<int> itemPool { get; set; }
    
            public void Initialize() {
                foreach (Character c in characters)
                    c.Initialize();
    
                //ItemPool.Load(itemPool.ToArray());
            }
            public Savefile() {
                itemPool = new List<int>();
                characters = new List<Character>();
            }
        }
    
        public class Character {
            internal void Initialize() {
                throw new NotImplementedException();
            }
        }
    
        [TestClass]
        public class UnitTestSerialization {
            [TestMethod]
            public void TestMethod1() { 
                FileStream stream = new FileStream("SaveFile.xml", FileMode.Open, FileAccess.Read); 
    
                XmlSerializer serializer2 = new XmlSerializer(typeof(Savefile));
                var newItem = (Savefile)serializer2.Deserialize(stream);
                Assert.IsNotNull(newItem);
    
                stream.Close();
            }
        }
    }
