    public class Base
    {
        private string ClientID;
        protected string Make(string param)
        {
            return this.ClientID + "_" + param;
        }
        protected void InvokeSiblingMake(Base other)
        {
            other.Make("hello world");
        }
    }
    public class Class2 : Base  
    {
    }
    public class Class3 : Base
    {
        //HERE i would like to call Make but with the THIS as Class2, not the current - Class3.
        public void Test(Class2 other)
        {
            InvokeSiblingMake(other);
        }
    }
