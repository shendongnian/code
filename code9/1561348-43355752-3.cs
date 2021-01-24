    public void Foo()
    {
        if ((NullCheck(Object1) != null) ? true : false)
        {
        ...
        }
    }
    private Nullable<Object4Type> NullCheck(Object1Type object1)
    {
        if(!Object.RefrenceEquals(object1, null)) //This is "Object1?."
        {
            var tmpObject2 = tmpObject1.Object2;
            if(!Object.RefrenceEquals(tmpObject2, null)) //This is "Object2?."
            {
                var tmpObject3 = tmpObject2.Object3;
                if(!Object.RefrenceEquals(tmpObject3, null)) //This is "Object3?."
                {
                    return tmpObject3.Object4;
                }        
            }
        }
        return default(Nullable<Object4Type>);
    }
