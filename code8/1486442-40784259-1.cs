    private SomeType _value;
    public SomeType CachedProperty {
         get {
              if(_value == null) {
                  _value = GetValue(); // slow
              }
              return _value;
         }
    }
