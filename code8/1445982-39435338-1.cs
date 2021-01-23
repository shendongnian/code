    public class C
    {
        public void M()
        {
            C c = new C();
            int? num = c != null ? new int?(c.SomeMethod()) : null;
            Console.WriteLine(num);
        }
        public int SomeMethod()
        {
            return 1;
        }
    }
