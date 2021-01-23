    public interface IProduct
    {
       int ProductId {get;set;}
    }
    
    public class ProductConverter<t> where T: Entity, IProduct
    {
       //Do sth. with your ProductId
    }
