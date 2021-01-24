    public void Parse(string Input)
    {
        if(Input!=null)
        {
           foreach (string s in Input.Split(' '))
           {
               Add(s);
           }
        }
    }    
