    [ComVisible(true)]
    public class FrameElementInterceptor
    {
        public void Intercept(string propKey, object[] args)
        {
            MessageBox.Show($@"Function '{propKey}' was called with arguments: [{string.Join(", ", args)}]",
    @"Function call intercepted");
        }
    }
    
    public Form1()
    {
        InitializeComponent();
     
        // .....
    
        browser.RegisterJsObject("frameElementInterceptor", new FrameElementInterceptor());
    }
