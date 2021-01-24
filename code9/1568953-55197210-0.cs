    using System;
    public class Window{
        protected void break1() {Console.Write("1");}
        public Window(){
            Glass.break1();
        }
    }
    public class Glass : Window{
        public static void break1() {Console.Write("2");}
        public Glass() {
            Glass.break1();
        }
    }
    public class Dijete : Glass{
        public Dijete() {
            Glass.break1();
        }
    }
    public class Program
    {
        public static void Main()
        {
            Glass.break1();
        }
    }
