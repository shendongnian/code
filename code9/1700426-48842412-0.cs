    public delegate void show(string s);
    namespace MyFunctions
    {
        public class main
        {
            public static void SHOW(string str)
            {
                MessageBox.Show(str);
            }
        }
    }
    
    namespace xyz
    {
        //use MyFunctions.main; // <--- something like that ??
        public class A : ProgramBase
        {
            public static event show show_event = MyFunctions.main.SHOW; // use delegate
            public void message()
            {
                show_event("Hi");
            }
        }
    }
