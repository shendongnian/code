    Class1 MyCounterClass;
    private void Form1_Load(object sender, EventArgs e)
    {
        MyCounterClass = new Class1();
        // register the event. The method on the right hand side 
        // will be called when the event is fired
        MyCounterClass.CountEvent += MyCounterClass_CountEvent;
    }
    private void MyCounterClass_CountEvent(int c)
    {
        if (textBox1.InvokeRequired)
        {
            textBox1.BeginInvoke(new Action(() => textBox1.Text = c.ToString()));
        }
        else
        {
            textBox1.Text = c.ToString();
        }
    }
