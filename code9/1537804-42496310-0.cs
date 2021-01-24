        class MyEntry
        {
            private Type _type = typeof(object);
            private bool _boolValue = false;
            private int _intValue = 0;
            public MyEntry(bool b)
            {
                _type = typeof(bool);
                _boolValue = b;
            }
            public MyEntry(int i)
            {
                _type = typeof(int);
                _intValue = i;
            }
            public static implicit operator bool(MyEntry e)
            {
                if (e._type != typeof(bool)) throw new InvalidCastException();
                return e._boolValue;
            }
            public static implicit operator MyEntry(bool b)
            {
                return new MyEntry(b);
            }
            public static implicit operator int(MyEntry e)
            {
                if (e._type != typeof(int)) throw new InvalidCastException();
                return e._intValue;
            }
            public static implicit operator MyEntry(int i)
            {
                return new MyEntry(i);
            }
        }
