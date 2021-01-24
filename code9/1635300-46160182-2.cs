    public class Myclass
    {
        public int MyProperty { get; private set; }
        public int MyProperty2 { get; }
        public void MyFunc()
        {
            MyProperty = 5; //This Is Legal
            MyProperty2 = 6; //This is not
        }
    }
