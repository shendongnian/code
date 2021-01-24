    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        public static class HashSetExtensions
        {
            public static HashSet<T> RegenerateHashSet<T>(this HashSet<T> original)
            {
                return new HashSet<T>(original, original.Comparer);
            }
        }
        public class Bean
        {
            public string Name { get; set; }
    
            public int Id { get; set; }
    
            public override bool Equals(object obj)
            {
                var bean = obj as Bean;
    
                if (bean == null)
                {
                    return false;
                }
    
                return Name.Equals(bean.Name) && Id == bean.Id;
            }
    
            public override int GetHashCode()
            {
                return Name.GetHashCode() * Id.GetHashCode();
            }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                HashSet<Bean> set = new HashSet<Bean>();
    
                Bean b1 = new Bean { Name = "n", Id = 1 };
                Bean b2 = new Bean { Name = "n", Id = 2 };
                set.Add(b1);
                set.Add(b2);
                b2.Id = 1;
    
                var elements = set.ToList();
    
                var elem1 = elements[0];
                var elem2 = elements[1];
    
                if (elem1.Equals(elem2))
                {
                    Console.WriteLine("elements are equal");
                }
                Console.WriteLine(set.Count);
                set = set.RegenerateHashSet();
                Console.WriteLine(set.Count);
                Console.ReadLine();
            }
        }
    }
