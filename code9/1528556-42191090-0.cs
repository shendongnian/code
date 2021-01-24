    internal class myBindingSource : BindingSource
        {
        private IDictionary<string, AClass> source;
        private System.ComponentModel.PropertyDescriptorCollection props;
        public myBindingSource(IDictionary<string, AClass> source)
            {
            this.source = source;
            props = System.ComponentModel.TypeDescriptor.GetProperties(typeof(AClass));
            this.DataSource = source;
            }
        public override System.ComponentModel.PropertyDescriptorCollection GetItemProperties(System.ComponentModel.PropertyDescriptor[] listAccessors)
            {
            return props;
            }
        public override object this[int index]
            {
            get {return this.source.Values.ElementAtOrDefault(index);}
            set {}
            }
        public override bool AllowNew
            {
            get { return false; }
            set{}
            }
        public override bool AllowEdit
            {
            get { return false; }
            }
        public override bool AllowRemove
            {
            get {return false;}
            }
        }
