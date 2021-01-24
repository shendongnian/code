    private void Form1_Load(object sender, EventArgs e)
    {
        webBrowser1.ObjectForScripting = this;
        webBrowser1.DocumentText =
            "<html><head><script>" +
            "function test(message) { alert(message); }" +
            "</script></head><body><button " +
            "onclick=\"window.external.Test('called from script code')\">" +
            "call client code from script code</button>" +
            "</body></html>";
    }
    public void Test(String message)
    {
        MessageBox.Show(message, "client code");
    }
    private void button1_Click(object sender, EventArgs e)
    {
        webBrowser1.Document.InvokeScript("test",
            new String[] { "called from client code" });
    }
