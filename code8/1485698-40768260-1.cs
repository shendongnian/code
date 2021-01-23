    public string MockFullName
    {
        get
        {
            string ns = FullName.Substring(0, FullName.Length - Name.Length - 1);
            return string.Format("{0}.Mock{1}", ns, Name);
            if(true)
            {
                DoStuff();
            }
        }
    }
    
    public string MockFullName
    {
        get
        {
            string ns = FullName.Substring(0, FullName.Length - Name.Length - 1);
            return string.Format("{0}.Mock{1}", ns, Name);
        }
    }
