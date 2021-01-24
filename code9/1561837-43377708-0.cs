    public abstract class ProductFactory
    {
        public abstract Product Create();
    }
    
    public class MyProductFactory : ProductFactory
    {
        private HelpData additionalData;
    
        public MyProductFactory(HelpData additionalData)
        {
             this.additionalData = additionalData;
        }
    
        public override Product Create()
        {
            return new MyProduct {Abc = additionalData.SomethingImportantForMyProduct};
        }
    }
    
    public class YourProductFactory : ProductFactory
    {
        public override Product Create()
        {
            return new YourProduct();
        }
    }
