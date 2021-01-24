    bool GetNonIgnoreNode<T>(ref ITree<T> input)
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
        if (GetNonIgnoreLeaf(ref input))
        {
            // do what you need to do when a non-Ignore node was found
        }
        else
        {
            // do what you need to do when everything including the leaf has Ignore
        }
    }
