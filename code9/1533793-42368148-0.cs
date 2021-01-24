    [TestMethod]
    public void IsEmpty_NoElements_ArrayBased()
    {
        var myStack = new Stack_ArrayBased_Example1(10);
        IsEmpty_NoElements(myStack)
    }
    [TestMethod]
    public void IsEmpty_NoElements_LinkedListBased()
    {
        var myStack = new Stack_LinkedListBased_Example1(10);
        IsEmpty_NoElements(myStack)
    }
    public void IsEmpty_NoElements(IStack myStack)
    {
        var exp = true;
        var act = myStack.IsEmpty();
        Assert.AreEqual(exp, act);
    }
