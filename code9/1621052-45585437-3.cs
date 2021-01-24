    void test1()
    {
        if (test2())
        {
            Debug.WriteLine("Initialization OK");
        }
    }
    bool test2()
    {
        return test3();
    }
    bool test3()
    {
        return xxx;
    }
