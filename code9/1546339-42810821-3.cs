    using System;
    using System.Collections.Generic;
    using System.Reflection;
 
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Person p1 = new Person("David", 33);
                Person p2 = new Person("David", 44);
    
                var changedProperties = GetChangedProperties(p1, p2);
            }
    
            public class Person
            {
                public Person(string name, int age)
                {
                    this.name = name;
                    this.age = age;
                }
    
                public int age { get; set; }
                public string name { get; set; }
            }
    
            public static List<string> GetChangedProperties(Object A, Object B)
            {
                if (A.GetType() != B.GetType())
                {
                    throw new System.InvalidOperationException("Objects of different Type");
                }
                List<string> changedProperties = ElaborateChangedProperties(A.GetType().GetProperties(), B.GetType().GetProperties(), A, B);
                return changedProperties;
            }
    
    
            public static List<string> ElaborateChangedProperties(PropertyInfo[] pA, PropertyInfo[] pB, Object A, Object B)
            {
                List<string> changedProperties = new List<string>();
                foreach (PropertyInfo info in pA)
                {
                    object propValueA = info.GetValue(A, null);
                    object propValueB = info.GetValue(B, null);
                    if (propValueA != propValueB)
                    {
                        changedProperties.Add(info.Name);
                    }
                }
                return changedProperties;
            }
        }
    }
