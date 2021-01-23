    public int divide(int a, int b)
    {
        int result = 0;
        try
        { 
            result = _divide(a, b);
        }catch(Exception e)
                          {
          //...
        }
        return result;
    }
    public int _divide(int a, int b) throw Exception{
        return a / b;
    }
