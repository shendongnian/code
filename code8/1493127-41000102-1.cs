    class A {
        static Dictionary<Type, A> _LastInstances = new Dictionary<Type, A>(); // because every subclass will inherit from A
        public static A LastInstance {
            get {
                if ( _LastInstances.ContainsKey(GetType()) ) {
                    return _LastInstances[GetType()];
                }
                return null;
            }
  
            protected set {
                if ( _LastInstances.ContainsKey(GetType()) ) {
                    _LastInstances[GetType()] = value;
                } else {
                    _LastInstances.Add(GetType(), value);
                }
            }
    }
    class B : A {
        public B(){
            LastInstance = this;
        }
    }
