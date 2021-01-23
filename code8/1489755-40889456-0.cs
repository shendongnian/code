        public static void Main(string[] args)
        {
            string str = "Test1,Test2,Test3";
            string test1 = MyFunction("Test1", "Test2", "Test3");
            string test2 = MyFunction(str.Split(','));
        }
        public static string MyFunction(params string[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in parameters)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }
