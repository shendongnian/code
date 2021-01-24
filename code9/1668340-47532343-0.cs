     class Program
    {
        static void Main(string[] args)
        {
            var result = new GenericImplementation<int>(1, GetGuid);
            Console.WriteLine( result.Invoke(1));
            Console.ReadLine();
        }
        public static Guid? GetGuid(int i)
        {
            //Do whateve you want to do
            return new Guid();
        }
    }
    class GenericImplementation<T>
    {
        Func<T, Guid?> _id;
        public GenericImplementation(int identifier, Func<T,Guid?> id)
        {
            _id = id;
        }
        public Guid? Invoke(T value)
        {
            return _id.Invoke(value);
        }
        public bool Equal<U>(U v1, U v2)
        {
            if (v1.GetType() == typeof(string))
            {
                return v1.ToString() == v2.ToString();
            }
            if (v1.GetType() == typeof(int))
            {
                return int.Parse(v1.ToString()) == int.Parse(v2.ToString());
            }
            if (v1.GetType() == typeof(object))
            {
                //Deep level comparision
                return true;
            }
            return false;
        }
    }
