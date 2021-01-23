    [TestMethod]
    public void _TestNullCoalesceningExtension() {
        var myEntity = new MyEntity 
        {
            Property = new AnotherEntity()
        };
        var myValue = myEntity.Property.IfNotNull(p => p.FirstProperty.SecondaryProperty);
        Assert.IsNull(myValue);
    }
    public class MyEntity {
        public AnotherEntity Property { get; set; }
    }
    public class AnotherEntity {
        public YetAnotherClass FirstProperty { get; set; }
    }
    public class YetAnotherClass {
        public object SecondaryProperty { get; set; }
    }
