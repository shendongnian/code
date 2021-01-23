    private void button1_Click(object sender, EventArgs e)
    {
        InvokeMyMethod((Action<string,int>) Test, "string", 1);
        InvokeMyMethod((Action<string,int,Color>) TestN, "other string", 3, Color.Red);
    }
    public void InvokeMyMethod(Delegate method, params object[] args)
    {
        method.DynamicInvoke(args);
    }
    public void Test(string s, int i)
    {
        MessageBox.Show(string.Format("{0}{1}", s, i));
    }
    public void TestN(string s, int i, Color c)
    {
        // or, whatewer
        MessageBox.Show(string.Format("{0}{1}{2}", s, i , c);
    }
