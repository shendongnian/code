        public static void Convert<TToConvert, TConverted>(TToConvert valueToConvert, out TConverted valueConverted)
        {
            // You should put the dictionary outside of the method
            // To avoid to instance it, each time you call this method
            var dict = new Dictionary<Type, Func<object, object>>()
            {
                { typeof(Tuple<string, int>), x => int.Parse((string)x) },
                { typeof(Tuple<string, bool>), x => bool.Parse((string)x) }
            };
            valueConverted = (TConverted)dict[typeof(Tuple<TToConvert, TConverted>)](valueToConvert);
        }
        static void Main(string[] args)
        {
            bool boolTest;
            Convert("false", out boolTest);
            Console.WriteLine(boolTest);
            int intTest;
            Convert("42", out intTest);
            Console.WriteLine(intTest);
            Console.ReadKey();
        }
