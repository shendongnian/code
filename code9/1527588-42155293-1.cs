    String value = "aaa.bbb.ccc";
    Int32 firstDotIdx = value.IndexOf( '.' );
    if( firstDotIdx > -1 ) {
        return new String[] {
            value.Substring( 0, firstDotIdx ),
            value.Substring( firstDotIdx + 1 );
        }
    } else {
        return new String[] {
            value,
            "";
        }
    }
