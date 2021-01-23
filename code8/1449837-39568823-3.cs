    class Program
    {
        static void Main(string[] args)
        {
            var converter = new Converter<string>();
            var converted_objected = converter.ConvertThis<int>(200);
            Console.Read();
        }
    }
    
    class Converter<T>
    {
        public T ConvertThis<O>(O to_convert)
        {
            T result = default(T);
            // do stuff with to_convert and the answer ends up in result
            return result;
        }
    }
