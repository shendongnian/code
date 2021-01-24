    string s = "AX_1234X_12345_X_CXY";
    string ns = HappyChap(s);
    public string HappyChap(string value)
    {
        int start = value.IndexOf("X_");
        int next = start;
        for(int c=start; c<=value.Length-1; c++)
        {
           next = value.IndexOf("X_", c + 1);
           if (next > 0)
           {                   
               value.Remove(next, 2);
           }
        }
        return value;
    }
