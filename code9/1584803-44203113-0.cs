    public class Foo
    {
        public event EventHandler EndOfVideo;
        protected virtual void OnEndOfVideo()
        {
            var handler = EndOfVideo;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
