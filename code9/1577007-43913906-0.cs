    public void SafeToString( Object a )
    {
        if( a != null )
            return a.ToString();
        return "null";
    }
    SafeToString( 42 );
