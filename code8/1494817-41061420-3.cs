    public Foo(Action onEventOne): this(onEventOne, null, true) { }
    public Foo(Action onEventOne, Action onEventTwo) : this(onEventOne, onEventTwo, false) { }
    public Foo(Action onEventOne, Action onEventTwo, bool internalUse)
    {
        _memberVariable = 0;
    
        _onEventOne = onEventOne;
        if(onEventTwo == null && !internalUse) throw new ArgumentNullException("onEventTwo");
        _onEventTwo = DefaultEventTwo;
    
        _onEventOne();
    }
