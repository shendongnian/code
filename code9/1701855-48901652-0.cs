    public class MyTimer : Timer
    {
        public event EventHandler EnabledChanged;
        public override bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                EnabledChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
