    public class CustomStackPanel : System.Windows.Controls.StackPanel
    {
        public CustomStackPanel()
        {
            Children.Add(new Button() { Content = "1" });
            Children.Add(new Button() { Content = "2" });
            Children.Add(new Button() { Content = "3" });
        }
    }
