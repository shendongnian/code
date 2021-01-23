    public delegate void ReachLengthHandler(object sender, EventArgs args);
    class Program
    {
        public event ReachLengthHandler handler;
        private const int Threshhold = 500;
        public string Info
        {
            set
            {
                if (value.Length > Threshhold)
                {
                    this.OnReachLength(null);
                }
            }
        }
        public void OnReachLength(EventArgs args)
        {
            this.handler?.Invoke(this, args);
        }
    }
