    abstract class Base
    {
        public abstract string DbName { get; }
    }
    class Product : Base
    {
        public override string DbName => "ProductDB";
    }
    class Sales : Base
    {
        public override string DbName => "SalesDB";
    }
    class DbConnection<T> where T : Base
    {
        public string Test(T instance) => instance.DbName;
    }
