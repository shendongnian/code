    class Program
    {
        static void Main(string[] args)
        {
            String [,] arr = new String[1,2];
            arr[0,0] = "Hello";
            arr[0,1] = "World";
            Console.WriteLine(JsonConvert.SerializeObject(arr));
            Console.ReadKey(true);
            //[["Hello","World"]]
        }
    }
