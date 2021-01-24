    class ModelBase
    {
        public Type KeyType { get; set; }
    }
    class ModelBase<TKey> : ModelBase
    {
        public TKey Id { get; set; }
        public ModelBase()
        {
            KeyType = typeof(TKey);
        }
    }
    class Repo<TModel> where TModel : ModelBase, new()
    {
        // code where I access both TModel and TKey types
        public void Test()
        {
            var modelType = typeof(TModel).Name;
            var keyType = new TModel().KeyType.Name;
            Console.WriteLine($"{modelType}     {keyType}");
        }
    }
