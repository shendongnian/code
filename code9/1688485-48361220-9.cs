    using System;
    using System.ComponentModel;
    using System.Linq;
    public class MyTypeDescriptor : CustomTypeDescriptor
    {
        ICustomTypeDescriptor d;
        SampleClass o;
        public MyTypeDescriptor(ICustomTypeDescriptor originalDescriptor, SampleClass owner)
            : base(originalDescriptor) { d = originalDescriptor; o = owner; }
        public override PropertyDescriptorCollection GetProperties()
        { return this.GetProperties(new Attribute[] { }); }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = base.GetProperties(attributes).Cast<PropertyDescriptor>()
                .Select(p => p.Name == "StringProperty" ? new MyPropertyDescriptor(p, o) : p)
                .ToArray();
            return new PropertyDescriptorCollection(properties);
        }
    }
