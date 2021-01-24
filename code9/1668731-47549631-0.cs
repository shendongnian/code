    struct myData
    {
        string st;
        int[,] table;
    }
    
    private myData MyFunc()
    {
        myData data = new myData()
        {
            st = ...,
            table = ...
        }
          
        return data;
    }
