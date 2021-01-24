    namespace ClassLibrary1
    {
        [ComVisible(true)]
        public interface IObject1
        {
            string MyProperty { get; }
        }
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        public class Object1 : IObject1
        {
            public string MyProperty { get => "42"; }
        }
    }
    // AssemblyInfo.cs
    [assembly: Guid("d1e7f7b4-3c3a-41e5-b0bf-5dec54050431")]
