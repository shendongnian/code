    ....
    
    while ((line = tr.ReadLine()) != null)
    {
        
        using (StreamWriter tw = new StreamWriter(@"d:\\My File3.log"))
        string st = line.Replace("a ", "a").Replace("b ", "b");//just add additional .Replace() here
        tw.WriteLine(st); 
    
    }
