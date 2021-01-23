    public interface IMask {}
    public class MyObject : IMask {}
    public class Driver
    {
        public static void main(string[] args)
        {
            Driver d = new Driver();
            MyObject mo = d.SomeMethod(/*some param*/);
        }
   
        public IMask<T> SomeMethod(/*some param*/) where T : IMask
        {
            //some code
            return new IMask();
        }
    }
