    string old  = "abc";
    string nw   = "aa";
    int counter = 0;
    
    using(StreamWriter w = new StreamWriter("newfile")
    {
        foreach(string s in File.ReadLines(path))
            w.WriteLine(s == old ? nw : s);
    }
          
