    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using Shouldly;
    using Xunit;
    
    namespace Tests
    {
        public class ObjectWithDisplayOrder
        {
            [Display(Order = 0)]
            public virtual string StringPropertyB { get; set; }
    
            [Display(Order = 0)]
            public virtual string StringPropertyA { get; set; }
        }
    
        public class DisplayOrderTests
        {
            [Fact]
            public void ShouldUpdateDisplayOrderProperty()
            {
                const int updatedOrderValue = 1000;
    
                var properties = typeof(ObjectWithDisplayOrder).GetProperties();
                foreach (var property in properties)
                {
                    var displayAttribute = (DisplayAttribute) property.GetCustomAttributes().First(a => a is DisplayAttribute);
                    var props = displayAttribute.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).ToList();
                    props.Single(p => p.Name == "Order").SetValue(displayAttribute, updatedOrderValue);
                    // displayAttribute Order is 1000 here, but it's not persisted...
                }
    
                foreach (var property in properties)
                {
                    var displayAttribute = (DisplayAttribute) property.GetCustomAttributes().First(a => a is DisplayAttribute);
                    displayAttribute.GetOrder().ShouldBe(updatedOrderValue); // Fails - Order is still 0
                }
            }
        }
    }
