    public abstract class Device
    {
        protected Device(string alias)
        {
            Alias = alias;
        }
        public string Alias { get; }
    }
    public class A1 : Device
    {
        public A1(string alias) : base(alias) { }
    }
    public class A2 : Device
    {
        public A2(string alias) : base(alias) { }
    }
    class DeviceAttribute : Attribute
    {
        public DeviceAttribute(Type type)
        {
            Type = type;
        }
        public Type Type { get; }
    }
    public enum DeviceEnum
    {
        [Device(typeof(A1))]
        A1,
        [Device(typeof(A2))]
        A2
    }
    public static class DeviceEnumExtension
    {
        public static Device GetInstance(this DeviceEnum obj, string alias)
        {
            var member = typeof(DeviceEnum).GetMember(obj.ToString());
            if (member[0].GetCustomAttributes(typeof(DeviceAttribute), false)[0] is DeviceAttribute deviceAttr)
            {
                var ctor = deviceAttr.Type.GetConstructor(new[] {typeof(string)});
                return ctor.Invoke(new object[] {alias}) as Device;
            }
            return null;
        }
    }
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var a1 = DeviceEnum.A1;
            var a2 = DeviceEnum.A2;
            // Act
            var instanceA1 = a1.GetInstance("A1");
            var instanceA2 = a2.GetInstance("A2");
            // Assert
            Assert.Equal(typeof(A1), instanceA1.GetType());
            Assert.Equal(typeof(A2), instanceA2.GetType());
            Assert.Equal("A1", instanceA1.Alias);
            Assert.Equal("A2", instanceA2.Alias);
        }
    }
