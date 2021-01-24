    bool MoveToNextNonIgnoreChild<T>(ref ITree<T> input)
    {
        while (input.Ignore)
        {
            input = input.Child;
            if (input == null)
                return false;
        }
        return true;
    }
    MyClass2 SomeMethod(MyClass1 input)
    {
        if (MoveToNextNonIgnoreChild(ref input))
        {
            ... // do MyClass1 specific stuff and finally return some instance of MyClass2
        }
        else
        {
            return null;
        }
    }
