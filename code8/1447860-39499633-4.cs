    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Xunit;
    
    namespace Company.Tests
    {
        public class MyObject
        {
            [Display(Order = 1000)]
            public virtual string StringPropertyB { get; set; }
    
            [Display(Order = 2000)]
            public virtual string StringPropertyA { get; set; }
        }
    
        public class MyObjectTest
        {
            [Fact]
            public void X()
            {
                var properties = typeof(MyObject).GetProperties();
                var stringPropertyBPropertyInfo = properties[0];
                var bDisplayAttribute = (DisplayAttribute)stringPropertyBPropertyInfo.GetCustomAttributes().First();
                var props = bDisplayAttribute.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).ToList();
                props.Single(p => p.Name == "Order").SetValue(bDisplayAttribute, 5);
                
            }
        }
    }
