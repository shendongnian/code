    public abstract class Product {}
    
    public class MyProduct : Product
    {
        public bool Abc { get; set; }
    }
    
    public class YourProduct : Product {}
    
    public class MyProductFactory
    {
        public Product Create(HelpData additionalData)
        {
            return new MyProduct {Abc = additionalData.SomethingImportantForMyProduct};
        }
    }
    
    public class YourProductFactory
    {
        //unused parameter
        public Product Create()
        {
            return new YourProduct();
        }
    }
    
    public class HelpData
    {
        public bool SomethingImportantForMyProduct { get; set; }
    }
