    private class WeakSubscriber1 : WeakReference
    {
        public WeakSubscriber1(Subscriber1 target) : base(target) { }
    
        public void ClickHander(object sender, EventArgs args)
        {
            Subscriber1 b = (Subscriber1)this.Target;
    
            if (b == null)
            {
                Button c = sender as Button;
    
                if (c != null)
                {
                    c.MyEvent -= new EventHandler(this.ClickHandler);
                }
            }
    
            else
            {
                b.Handler1(sender, args);
            }
        }
    }
