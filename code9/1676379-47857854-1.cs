    public class GameButton : System.Windows.Forms.Button
    {
        System.Windows.Forms.Timer timer;
    
        public GameButton(string text, Rectangle rect, Color backgroundColor, TimeSpan interval)
            : base()
        {
            Location = rect.Location;
            Size = rect.Size;
            Text = text;
            BackColor = backgroundColor;
            timer = new Timer();
            timer.Interval = Convert.ToInt32(interval.TotalMilliseconds);
            timer.Tick += Button_Tick;
            timer.Start();
        }
        private void Button_Tick(object sender, EventArgs e)
        {
            BackColor = ????;
        }
        public new void Dispose()
        {
            timer.Dispose();
            base.Dispose();
        }
    }
