    public void SetText(string text)
    {
        Form1 fm = new Form1();
    
        Console.WriteLine("set text");
        Console.WriteLine(text);
        textToDisplay = text;
        fm.Invoke((MethodInvoker)delegate{ tbE.Text = textToDisplay; });    
    }
