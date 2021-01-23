        public static void Write((Base t, Base u) things)
        {
            Console.WriteLine($"t: {things.t}, u: {things.u}");
        }
        public class Base { }
        public class Derived : Base { }
