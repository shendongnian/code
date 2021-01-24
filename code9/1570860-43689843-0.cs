    void m1 ()
    {
        int a;
        //a exists
        {
            int b;
            //a and b exist
        }
        //only a exists
    }
    //nothing exists
    void m2 ()
    {
        //still nothing exists
        int c;
        //Only c exists
    }
