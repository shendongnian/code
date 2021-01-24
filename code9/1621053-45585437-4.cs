    bool test4()
    {
        if (test1())
        {
            if (test2())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
