    public class TextBoxWithDelay : TextBox
    {
        public TextBoxWithDelay()
        {
            this.DelayInSeconds = 10;
            this.TextChanged += OnTextChangedWaitForDelay;
        }
        public int DelayInSeconds { get; set; }
        public event EventHandler TextChangedWaitForDelay;
        private Timer t;
        private void OnTextChangedWaitForDelay(object sender, EventArgs args)
        {
            if (t != null)
            {
                t.Stop();
            }
            else
            {
                t = new Timer();
                t.Tick += DoIt;
            }
            
            t.Interval = 1000 * DelayInSeconds;
            t.Start();
        }
        public void DoIt(object sender, EventArgs args)
        {
            if (TextChangedWaitForDelay != null)
            {
                TextChangedWaitForDelay.Invoke(sender, args);
                t.Stop();
            }
            
        }
    }
