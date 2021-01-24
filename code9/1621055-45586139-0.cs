    bool flag;
    void test1()
    {
        test2();
        if (flag) {
            // do other stuff
            Debug.WriteLine("Initialization OK");
        }
        else {
             Debug.WriteLine("Initialization NOT OK");
        }
    }
    void test2()
    {
        test3();            
        if (flag) {
            // do other stuff 
        }
    }
    void test3()
    {
        if (xxx)
            return;
        // do other stuff
        flag = true;
    }
