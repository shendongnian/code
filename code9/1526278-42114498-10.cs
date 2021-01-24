    namespace ClassLibrary1
    {
        using System.Collections.Generic;
        using System.Linq;
    
        public static class Worker
        {
            // NOTE: Thanks to internal on the IWriter, you can't return IWriter here.
            public static IEnumerable<IReader> DoSomething()
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
    
                return structs.Cast<IReader>();
            }
        }
    }
    
