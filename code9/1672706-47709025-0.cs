    MethodInvoker methodInvokerDelegate = delegate() 
    { 
        pictureBox1.Visible = false;
        pictureBox1.Enabled = false;
        pictureBox2.Visible = false;
        pictureBox2.Enabled = false;
        pictureBox3.Visible = true;
        pictureBox3.Enabled = true; 
    };
    //This will be true if Current thread is not UI thread.
    if (this.InvokeRequired)
        this.Invoke(methodInvokerDelegate);
    else
        methodInvokerDelegate();
