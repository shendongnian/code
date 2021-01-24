    namespace ClassLibrary2
    {
        [ComVisible(true)]
        public interface IInterface1
        {
            IObject1 Object1 {get;}
        }
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        public class Interface1 : IInterface1
        {
            IObject1 IInterface1.Object1 { get => new Object1(); }
        }
    }
    // AssemblyInfo.cs
    [assembly: Guid("a7a14989-71da-49d4-87be-85c4b87bcaf0")]
