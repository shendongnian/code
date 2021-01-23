    public class MongoObserver<TCollection> : IMongoObserver<TCollection>
    {
        private volatile UpdateDefinition<TCollection> _definition;
        public void OnPropertyChanged<TField>(Expression<Func<TCollection, TField>> func, TField value)
        {
            if (Definition != null)
            {
                Definition.Set(func, value);
            }
            else
            {
                _definition = Builders<TCollection>.Update.Set(func, value);
            }
        }
        public UpdateDefinition<TCollection> Definition => _definition;
    }
