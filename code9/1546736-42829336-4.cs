    using System;
    using System.ComponentModel;
    using System.Linq;
    public class MyPropertyDescriptor : PropertyDescriptor
    {
        PropertyDescriptor o;
        public MyPropertyDescriptor(PropertyDescriptor originalProperty)
            : base(originalProperty) { o = originalProperty; }
        public override bool CanResetValue(object component)
        { return o.CanResetValue(component); }
        public override object GetValue(object component) { return o.GetValue(component); }
        public override void ResetValue(object component) { o.ResetValue(component); }
        public override void SetValue(object component, object value) 
        { o.SetValue(component, value); }
        public override bool ShouldSerializeValue(object component) 
        { return o.ShouldSerializeValue(component); }
        public override AttributeCollection Attributes
        {
            get
            {
                var attributes = base.Attributes.Cast<Attribute>().ToList();
                var category = attributes.OfType<CategoryAttribute>().FirstOrDefault();
                if (category != null && category.Category == "Extra")
                    attributes.Add(new BrowsableAttribute(false));
                return new AttributeCollection(attributes.ToArray());
            }
        }
        public override Type ComponentType { get { return o.ComponentType; } }
        public override bool IsReadOnly { get { return o.IsReadOnly; } }
        public override Type PropertyType { get { return o.PropertyType; } }
    }
