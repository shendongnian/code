        public delegate void myDelegate(double x, string s);
        //declaration of   delegate
        public static void func(double x, string s)
        {
            //dosomethings...
        }
        // what is the declaration of the argument 'Function declaration'
        public static void myFunction(myDelegate function)
        {
            myDelegate deFunc;
            deFunc = function;
        }
        static void Main(string[] args)
        {
            myFunction(func);
        }
