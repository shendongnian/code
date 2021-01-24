    public interface IConstantsDefined
    {
        string DbName { get };
        string TableName { get };
        string ColumnName { get };
    }
    
    public class Product : IConstantsDefined
    {
        public string DbName { get { return "ProductDB" } };
        public string TableName { get { return "Products" } };
        public string ColumnName { get { return "ProductId" } };
    }
    
    public class Sales: IConstantsDefined
    {
        public string DbName { get { return "ProductDB" } };
        public string TableName { get { return "Sales" } };
        public string ColumnName { get { return "SaleId" } };
    }
