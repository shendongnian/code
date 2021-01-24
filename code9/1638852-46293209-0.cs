    public class Category
    {
        public string prop1;
        public string prop2;
    }
    public class Data
    {
        public List<Category> categories;
    }
    
    public class RootObject
    {
        public int code;
        public string message;
        public Data data;
    }
