        public static void Main()
        {
            string s = "T";
            //THIS WILL THROW A FORMATEXCEPTION
            double d = Convert<string, double>(s);
            Console.WriteLine(d);
        }
