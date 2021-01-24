    // DerivedChildControlA.ascx
    <uc1:ChildControl runat="server" ID="someChildControlID" />
    
    
    public abstract class BaseControl : UserControl
    {
        protected abstract ChildControl DerivedChild { get; }
    }
    
    public class DerivedChildControlA : BaseControl
    {
        protected override ChildControl DerivedChild
        {
            get { return this.someChildControlID; }
        }
    }
