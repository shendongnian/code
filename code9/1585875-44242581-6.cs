    public class ConstantsDefined
    {
        public string DbName { get; private set; };
        public string TableName { get; private set; };
        public string ColumnName { get; private set; };
        public static readonly ConstantsDefined Product = new ConstantsDefined()
        {
            DbName = "ProductDB",
            TableName = "Products",
            ColumnName = "ProductId",
        };
    }
