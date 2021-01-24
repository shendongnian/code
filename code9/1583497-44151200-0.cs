    public void NewMethod(string s1, string s2, string s3, string s4)
    {
        string[] nonEmpty = new string[] { s1, s2, s3, s4 }.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        if (nonEmpty.Length == 4)
        {
            oldmethod(s1, s2, s3, s4);
        }
        else if (nonEmpty.Length == 3)
        {
            oldmethod(s1, s2, s3);
        }
        else
        {
            // unexpected, fix or throw
        }
    }
