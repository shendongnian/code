    public static string DoFormat( double myNumber )
    var s = string.Format("{0:0.00}", myNumber);
    if ( s.EndsWith("00") )
    {
        return ((int)myNumber).ToString();
    }
    else
    {
        return s;
    }
}
