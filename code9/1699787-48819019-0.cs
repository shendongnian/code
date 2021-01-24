        public interface IInitializable
        {
            public void Init(...parameters...)
        }
        public static T CreateInstanceOf<T>(Action<T> configure = null) where T : new(), IInitializable
        {
              T = new T();
              T.Initialize(...parameters...);
              ...
        }
