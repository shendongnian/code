    public class Wrapped<T> where T : new()
    {
        private T _instance;
        public void New()
        {
            _instance = new T();
        }
        public void Import(T t)
        {
            _instance = t;
        }
        public S Call<S>(Func<T, S> method)
        {
            //do something before
            var result = method(_instance);
            //do something after
            return result;
        }
        public void Call(Action<T> method)
        {
            //do something before
            method(_instance);
            //do something after
        }
    }
