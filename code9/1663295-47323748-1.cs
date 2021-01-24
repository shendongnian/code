    var s = "0123456";
    var even = new StringBuilder();
    var odd = StringBuilder();
    for(int i=0; i<s.Length;i++)
    {
        if(i % 2 == 0)
        {
            even.Append(s[i]);
        }
        else
        {
            oddAppend(s[i]);
        }
    }
    var result = even.Append(odd.ToString()).ToString();
