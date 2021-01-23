    private void DoWorkInThread(object sender, EventArgs e)
    {
        while (true)
        {
            lock(this)
            {
                    //update member properties
            }
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate void ()
                {
                    this.Invalidate();
                });
        }    
    }
    protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        lock(this)
        {
            //read your member which are modifies by the thread
        }
        //do rendering
        e.Graphics.Draw(...);
   } 
