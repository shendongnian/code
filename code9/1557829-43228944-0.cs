    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var a = new UserData();
                var b = new UserData();
    
                var aS = ObjectToByte(a);
                var bS = ObjectToByte(b);
                Console.WriteLine("A : {0}", a);
                Console.WriteLine("B : {0}", b);
                // result for empty objects are equal
                Console.WriteLine("A == B ? => {0} \n\n", aS.SequenceEqual(bS));
    
                a = new UserData()
                {
                    ForeName = "A",
                    Initials = "CC",
                    SurName = "B",
                };
    
                b = new UserData()
                {
                    ForeName = "AX",
                    Initials = "CC",
                    SurName = "B",
                };
    
                aS = ObjectToByte(a);
                bS = ObjectToByte(b);
    
                Console.WriteLine("A : {0}", a);
                Console.WriteLine("B : {0}", b);
                // result for same data type with same object values are equal
                Console.WriteLine("A == B ? => {0} \n\n", aS.SequenceEqual(bS));
    
                a = new UserData()
                {
                    ForeName = "AX",
                    Initials = "CC",
                    SurName = "B",
                };
                b = a;
    
                aS = ObjectToByte(a);
                bS = ObjectToByte(b);
    
                Console.WriteLine("A : {0}", a);
                Console.WriteLine("B : {0}", b);
                // result for different objects are not equal
                Console.WriteLine("A == B ? => {0} \n\n", aS.SequenceEqual(bS));
            }
    
            static byte[] ObjectToByte(object item)
            {
                var formatter = new BinaryFormatter();
                using (var memory = new MemoryStream())
                {
                    formatter.Serialize(memory, item);
                    return memory.ToArray();
                }
            }
        }
    
        [Serializable]
        public class UserData
        {
            public string SurName { get; set; }
            public string ForeName { get; set; }
            public string Initials { get; set; }
    
            public override string ToString()
            {
                return string.Format("{{SurName: {0} , ForeName:{1}, Initials:{2}}}", SurName ?? "Empty", ForeName ?? "Empty", Initials ?? "Empty");
            }
        }
    }
