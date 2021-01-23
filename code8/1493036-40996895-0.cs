    public delegate void InvokeDelegate();
    private string textToDisplay;
    public void SetText(string text)
    {
        Form1 fm = new Form1();
        Console.WriteLine("set text");
        Console.WriteLine(text);
        textToDisplay = text;
        Form1.tbE.BeginInvoke(new InvokeDelegate(InvokeMethod));     
    }
    public void InvokeMethod()
    {
        Form1.tbE.Text = textToDisplay;
    }
