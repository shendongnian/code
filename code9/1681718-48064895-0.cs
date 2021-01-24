    public class MyCustomBinding : Binding
    {
        public MyCustomBinding(string path)
            :base(path)
        {
            StringFormat = "yyyy-MM-dd";
        }
    }
