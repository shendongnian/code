    public class SomeWindow : System.Windows.Window
    {
        public SomeWindow()
        {
            this.AddChild(new System.Windows.Controls.Button() { Content = "OK", Height = 30, Width = 100 });
        }
    }
