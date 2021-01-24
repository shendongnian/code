    class MainForm : Form
    {
        private readonly AutoResetEvent _global = new AutoResetEvent();
        public override void Dispose()
        {
            _global.Dispose();
            base.Dispose();
        }
    }
        
