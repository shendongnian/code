    Class2 FindClassTwoByKey(Stack<Class1> stack, string key)
    {
        foreach (var class1 in stack)
        {
            if (class1.ClassTwos.ContainsKey(key))
            {
                // We found a match. Return it. We're done.
                return class1.ClassTwos[key];
            }
        }
        return null;
    }
