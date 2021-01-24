    private MyPropertyType myProperty = ...;
    public MyPropertyType MyProperty
    {
        get {return myProperty; }
        set
        {
             if (value != this.myProperty)
             {   // value changed: update + event
                 this.myProperty = value;
                 this.OnMyPropertyChanged();
             }
        }
    }
