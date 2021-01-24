    namespace ConsoleApplication3
    {
        using System.Collections.Generic;
        using System.Linq;
    
        public interface IReader
        {
            int Property1 { get; }
            string Property2 { get; }
        }
    
        internal interface IWriter : IReader
        {
            new int Property1 { get; set; }
            new string Property2 { get; set; }
        }
    
        public class Program
        {
            private static void Main(string[] args)
            {
                var structs = new HashSet<IWriter>();
                structs.Add(new SomeObject());
                structs.Add(new SomeObject());
                structs.Add(new SomeObject());
    
                int i = 0;
                foreach (IWriter s in structs)
                {
                    s.Property1 = ++i;
                    s.Property2 = i.ToString();
                }
    
                var readerCollection = structs.Cast<IReader>();
    
                var firstStruct = readerCollection.FirstOrDefault();
                //firstStruct.Property1 = 10
            }
        }
    
        public class SomeObject : IWriter
        {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
        }
    }
