    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    namespace Testing
    {
    
    
        public class Property
        {
            public string Name { get; set; }
    
            public override bool Equals(object obj)
            {
                var item = obj as Property;
    
                if (item == null)
                {
                    return false;
                }
                return item.Name == Name;
            }
    
            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
    
        }
    
        public class JoinedProperty
        {
            public Property Name1 { get; set; }
            public Property Name2 { get; set; }
    
            public override string ToString()
            {
                return (Name1 == null ? "" : Name1.Name)
                    + (Name2 == null ? "" : Name2.Name);
            }
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var list1 = new List<Property>
            {
                new Property{ Name = "A" },
                new Property{ Name = "A" },
                new Property{ Name = "A" },
                new Property{ Name = "B" }
            };
    
                var list2 = new List<Property>
            {
                new Property{ Name = "A" },
                new Property{ Name = "B" },
                new Property{ Name = "B" }
            };
    
                var allLetters = list1.Union(list2).Distinct().ToList();
                
                var result = new List<JoinedProperty>();
    
                foreach (var letter in allLetters)
                {
                    var list1Count = list1.Count(l => l.Name == letter.Name);
                    var list2Count = list2.Count(l => l.Name == letter.Name);
    
                    var matchCount = Math.Min(list1Count, list2Count);
    
                    addValuesToResult(result, letter, letter, matchCount);
    
                    var difference = list1Count - list2Count;
    
                    if(difference > 0)
                    {
                        addValuesToResult(result, letter, null, difference);                   
                    }
                    else
                    {
                        difference = difference * -1;
                        addValuesToResult(result,null, letter, difference);                   
                    }
                }
                foreach(var res in result)
                {
                    Console.WriteLine(res.ToString());
                }
                Console.ReadLine();
                
            }
    
            private static void addValuesToResult(List<JoinedProperty> result, Property letter1, Property letter2, int count)
            {
    
                for (int i = 0; i < count; i++)
                {
                    result.Add(new JoinedProperty
                    {
                        Name1 = letter1,
                        Name2 = letter2
                    });
                }
    
            }
        }
    }
