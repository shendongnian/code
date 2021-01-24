    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace Serialization_Help
    {
        class Program {
            static void Main(string[] args) {
                List<Cocktail> list = new List<Cocktail> {
                    new Cocktail(01, "rum and coke", true, true, 5),
                    new Cocktail(02, "water on the rocks", false, true, 3)
                };
                Serialize(list);
                List<Cocktail> deserialized = DiserializeFunc();
            }
    
            public static void Serialize(List<Cocktail> list) {
    
                XmlSerializer serializer = new XmlSerializer(typeof(List<Cocktail>));
                using (TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\ListCocktail.xml")) serializer.Serialize(writer, list);
            }
    
            private static List<Cocktail> DiserializeFunc() {
                var myDeserializer = new XmlSerializer(typeof(List<Cocktail>));
                using (var myFileStream = new FileStream(Directory.GetCurrentDirectory() + @"\ListCocktail.xml", FileMode.Open)) return (List<Cocktail>)myDeserializer.Deserialize(myFileStream);
            }
        }
    }
