    public class MyLabel : Label
    {
        SynchronizationContext UIContext;
        List<string> TextQueue;
        public MyLabel()
        {
            UIContext = SynchronizationContext.Current;
            TextQueue = new List<string>();
        }
    
        public override string Text
        {
            get { return base.Text; }
            set
            {
                Debug.WriteLine("Setting " + value);
                Thread.Sleep(1000);
                base.Text = value;
            }
        }
    
        public void QueueTextChange(string text)
        {
            Debug.WriteLine("Request: " + text);
            lock (TextQueue)
            {
                TextQueue.Add(text);
            }
            UIContext.Post((x) => { SetTextFromQueue();}, null);
        }
    
        void SetTextFromQueue()
        {
            string last=null;
            lock (TextQueue)
            {
                if (TextQueue.Count > 0)
                {
                    last = TextQueue.Last();
                    TextQueue.Clear();
                }
            }
            if (last != null)
                Text = last;
        }
    }
