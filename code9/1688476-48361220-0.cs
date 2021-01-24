    using System;
    using System.ComponentModel;
    using System.Linq;
    public class MyPropertyDescriptor : PropertyDescriptor
    {
        PropertyDescriptor p;
        SampleClass o;
        public MyPropertyDescriptor(PropertyDescriptor originalProperty, SampleClass owenr)
            : base(originalProperty) { p = originalProperty; o = owenr; }
        public override bool CanResetValue(object component)
        { return p.CanResetValue(component); }
        public override object GetValue(object component) { return p.GetValue(component); }
        public override void ResetValue(object component) { p.ResetValue(component); }
        public override void SetValue(object component, object value)
        { p.SetValue(component, value); }
        public override bool ShouldSerializeValue(object component)
        { return p.ShouldSerializeValue(component); }
        public override AttributeCollection Attributes { get { return p.Attributes; } }
        public override Type ComponentType { get { return p.ComponentType; } }
        public override bool IsReadOnly { get { return !o.Editable; } }
        public override Type PropertyType { get { return p.PropertyType; } }
    }
