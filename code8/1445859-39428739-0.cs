    public static Mymain CreateInstance(MyEnum attribute)
    {
        if(attribute == MyEnum.Value1)
        {
            return new MyClassA();
        }
        else
        {
            //...
        }
    }
