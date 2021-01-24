    public enum MyEnum
        {
            first , second 
        }
    public class VmCall : MarkupExtension
    {
        public MyEnum ActionName { get; }
        public VmCall(MyEnum actionName)
        {
            ActionName = actionName;
        }
        //.....
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
