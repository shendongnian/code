    //// Your old code...
    //Console.WriteLine("xyz1");
    //Console.WriteLine("xyz2");
    //// 1 .. 10 => 10 WriteLines e.g.
    //Console.WriteLine("xyz10");
    //// Your new code:
    List<string> ls = new List<string>();
    ls.Add("xyz1");
    ls.Add("xyz2");
    //// 1 .. 10 => 10 Add e.g.
    ls.Add("xyz10");
    this.textbox1.Multiline = true;
    foreach (string s in ls)
    {
        this.textbox1.Text += System.Environment.NewLine + s;
    }
