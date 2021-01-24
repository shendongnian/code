    public bool isEven(double value)
    {
       decimal decVal = System.Convert.ToDecimal(value);
        if (decVal % 2.0 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
