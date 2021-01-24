    using System;
    using System.ComponentModel;
    public class MyTypeDescriptionProvider : TypeDescriptionProvider
    {
        public MyTypeDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(object))) { }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type type, object o)
        {
            ICustomTypeDescriptor baseDescriptor = base.GetTypeDescriptor(type, o);
            return new MyTypeDescriptor(baseDescriptor);
        }
    }
