    internal Foo(Action onEventOne): this(onEventOne, null, true) { }
    // public API: NULL not allwoed as param
    public Foo(Action onEventOne, Action onEventTwo) : this(onEventOne, onEventTwo, false) { }
    internal Foo(Action onEventOne, Action onEventTwo, bool internalUse)
    {
        _memberVariable = 0;
    
        _onEventOne = onEventOne;
        if(onEventTwo == null)
        {
            if(!internalUse) throw new ArgumentNullException("onEventTwo");
            else this._onEventTwo = DefaultEventTwo;
        }
        _onEventOne();
    }
