    abstract class Animal<T> :Animal where T : class
        {
            public static int NumberOfLegs
            {
                get => _legsDictionary.ContainsKey(typeof(T)) ? _legsDictionary[typeof(T)] : -1;
                set
                {
                    _legsDictionary[typeof(T)] = value;
                }
            }
        }
