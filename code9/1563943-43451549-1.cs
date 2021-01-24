    int temp = 0;
    foreach(var s in items)
    {
        if (temp == 0)
                {
                    if (s == "a" || s == "b")
                    {
                        temp = 1;        
                    }
                }
                else
                {                
                    s = s.Replace(" ", "");
                    using (StreamWriter tw = new StreamWriter(@"d:\\My File3.log"))  
                    tw.WriteLine(s);
                    temp = 0;
                }
        }
