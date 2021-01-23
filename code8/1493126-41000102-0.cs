    class A {
        static Dictionary<Type, A> _LastInstances = new Dictionary<Type, A>(); // because every subclass will inherit from A
        public static A LastInstance {
            if ( _LastInstances.ContainsKey(GetType()) ) {
                return _LastInstances[GetType()];
            }
            return null;
        }
    }
    class B : A {
        public B(){
            if ( _LastInstances.ContainsKey(GetType()) ) {
                _LastInstances.Add(GetType(), this);
            } else {
                _LastInstances[GetType()] = this;
            }
        }
    }
