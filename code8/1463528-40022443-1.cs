    public class SlowScroller
    {
        private UltraGridRow current = null;
        private UltraGrid grd = null;
        private System.Windows.Forms.Timer t = null;
        public SlowScroller(UltraGrid grid)
        { 
             grd = grid; 
             t = new System.Windows.Forms.Timer();
        }
    
        public void Start(int interval)
        {
            t.Interval = interval;
            t.Tick += onTick;
            t.Start();
        }
        public void Stop()
        {
            if (t.Enabled)
               t.Stop();
        }
        private void onTick(object sender, EventArgs e)
        {
            if(current == null) 
                current = grd.Rows[0];
            else
                current = current.GetSibling(SiblingRow.Next);
            current.Activate();
        }
    }
