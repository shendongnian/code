    [DesignerAttribute(typeof(designPropDesigner))]
    public class designProp : Component
    {
        public class designPropDesigner : ComponentDesigner
        {
            private string _prop;
            public override void Initialize(IComponent component)
            {
                base.Initialize(component);
                this.prop = "value";
            }
            protected override void PreFilterProperties(IDictionary properties)
            {
                base.PreFilterProperties(properties);
                var prop = TypeDescriptor.CreateProperty(typeof(designPropDesigner), "prop", typeof(string), new Attribute[] { DesignOnlyAttribute.Yes, new DefaultValueAttribute("") });
                properties.Add("prop", prop);
            }
            private string prop
            {
                get
                {
                    return _prop;
                }
                set
                {
                    _prop = value;
                }
            }
        }
    }
