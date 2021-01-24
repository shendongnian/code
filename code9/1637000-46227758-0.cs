    public class FromHeaderOrBodyAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => new HeaderOrBodyBindingSource();
    }
    public class HeaderOrBindingSource : BindingSource
    {
        public HeaderOrBindingSource() : base("HeaderOrBody", "Header or Body binding source", true, true)
        {
        }
        public override bool CanAcceptDataFrom(BindingSource bindingSource)
        {
            return bindingSource == BindingSource.Header
                || bindingSource == BindingSource.Body;
        }
    }
