    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    public interface IMyInterface
    {
        string MyProperty1 { get; set; }
        string MyProperty2 { get; set; }
    }
    public class MyTypeDescriptionProvider<T> : TypeDescriptionProvider
    {
        public MyTypeDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(T))) { }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType,
            object instance)
        {
            return base.GetTypeDescriptor(typeof(T), instance);
        }
    }
    [TypeDescriptionProvider(typeof(MyTypeDescriptionProvider<IMyInterface>))]
    public class MyPanel : Panel, IMyInterface
    {
        public string MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
    }
