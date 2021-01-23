    private SomeType _value;
    public SomeType CashedProperty {
         get {
              if(_value == null) {
                  _value = GetValue(); // slow
              }
              return _value;
         }
    }
