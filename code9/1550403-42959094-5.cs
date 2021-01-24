    public class ListOfTypes<T>
    {
        private List<Type> _types = new List<Type>();
        public void Add<U>() where U : T
        {
            _types.Add(typeof(U));
        }
    }
