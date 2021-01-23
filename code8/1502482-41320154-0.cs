    public class A<T>
    {
        public class B : A<int>
        {
            public void M() { System.Console.WriteLine(typeof(T)); }
            public class C : A<T>.B { }
        }
    }
    public class P
    {
        public static void Main()
        {            
            (new A<string>.B.C()).M(); //Outputs System.String
    	}
    }
