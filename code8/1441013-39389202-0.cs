    internal class Messenger
    {
        public event EventHandler<string> DoWork;
        public void RaiseDoWork(string path)
        {
            this.DoWork?.Invoke(this, path);
        }
    }
