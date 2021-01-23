    var dataCust = method.GetCustomAttributesData()[0];
    var ctorParams = dataCust.GetType().GetField("m_ctorParams", BindingFlags.Instance | BindingFlags.NonPublic);
    var reflParams = ctorParams.GetValue(dataCust);
    var results = new List<Test[]>();
    bool a = reflParams.GetType().IsArray;
    if (a)
    {
        var mya = reflParams as Array;
        for (int i = 0; i < mya.Length; i++)
        {
            object o = mya.GetValue(i);
            ctorParams = o.GetType().GetField("m_encodedArgument", BindingFlags.Instance | BindingFlags.NonPublic);
            reflParams = ctorParams.GetValue(o);
            var array = reflParams.GetType().GetProperty("ArrayValue", BindingFlags.Instance | BindingFlags.Public);
            reflParams = array.GetValue(reflParams);
            
            if (reflParams != null)
            {
                var internal_array = reflParams as Array;
                var resultTest = new List<Test>();
                foreach (object item in internal_array)
                {
                    ctorParams = item.GetType().GetField("m_primitiveValue", BindingFlags.Instance | BindingFlags.NonPublic);
                    reflParams = ctorParams.GetValue(item);
                    resultTest.Add((Test)int.Parse(reflParams.ToString()));
                }
                results.Add(resultTest.ToArray());
            } else
            {
                results.Add(null);
            } 
            
        }
    }
    
