    public class SafeContentPage : ContentPage
    {
        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (Parent == null)
                DisposeBindingContext();
        }
        protected void DisposeBindingContext()
        {
            if (BindingContext is IDisposable disposableBindingContext) {
                disposableBindingContext.Dispose();
                BindingContext = null;
            }
        }
        ~SafeContentPage()
        {
            DisposeBindingContext();
        }
    }
