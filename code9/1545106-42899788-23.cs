    [Guid("00000000-0000-0000-0000-000000000001")] //GUID of ToolWindow
    public class MyToolWindow : ToolWindowPane
    {
        public MyToolWindow() : base(null)
        {
            this.Content = new MyWindowControl();
        }
    }
