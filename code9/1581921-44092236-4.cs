    List<Class2> FindClassTwosByKey(Stack<Class1> stack, string key)
    {
        var result = new List<Class2>();
        foreach (var class1 in stack)
        {
            if (class1.ClassTwos.ContainsKey(key))
            {
                result.Add(class1.ClassTwos[key]);
            }
        }
        return result;
    }
