    IEnumerable<string> GetNames(string input)
    {
        var builder=new StringBuilder(20);
        bool started=false;
        foreach(var c in input)
        {        
            if (started)
            {
                if (c!='$')
                {
                    builder.Append(c);
                }
                else
                {
                    started=false;
                    var value=builder.ToString();
                    yield return value;
                    builder.Clear();
                }
            }
            else if (c=='$')
            {
                started=true;
            }        
        }
    }
