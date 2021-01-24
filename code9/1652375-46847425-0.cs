    namespace ConsoleApp2
    {
        using System;
        using System.Linq.Expressions;
        using System.Reflection;
    
        static class Program
        {
            // your old method:
            public static string GetName<T>(string propName)
            {
                var propertyInfo = typeof(T).GetProperty(propName);
    
                var nameAttribute = propertyInfo.GetCustomAttribute(typeof(NameAttribute)) as NameAttribute;
    
                return nameAttribute.Name;
            }
    
            // new syntax method. Still calls your old method under the hood.
            public static string GetName<TClass, TProperty>(Expression<Func<TClass, TProperty>> action)
            {
                MemberExpression expression = action.Body as MemberExpression;
                return GetName<TClass>(expression.Member.Name);
            }
            
            static void Main()
            {
                // you had to type "TestClass" twice
                var name = GetName<TestClass>(nameof(TestClass.NamedProperty));
    
                // slightly less intuitive, but no redundant information anymore
                var name2 = GetName((TestClass x) => x.NamedProperty);
    
                Console.WriteLine(name);
                Console.WriteLine(name2);
                Console.ReadLine();
            }
        }
        [AttributeUsage(AttributeTargets.Property)]
        class NameAttribute : Attribute
        {
            public string Name { get; }
    
            public NameAttribute(string name)
            {
                this.Name = name;
            }
        }
        
        class TestClass
        {
            [Name("SomeName")]
            public object NamedProperty { get; set; }
        }
    }
