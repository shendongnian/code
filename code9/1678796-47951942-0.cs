        public static bool PopulateModelByDictionaryOne<TModel,TDataSource,TKey,TValue>(TDataSource dataSource)
                where TModel:IDicationaryDataModel<TKey,TValue>,new()
            where TDataSource:IDataSource<TKey,TValue>
        {
            var model = new TModel();
            foreach (var Item in dataSource.DictOne)
            {
                model.Dictionary.Add(Item.Key, Item.Value);
            }
            return true;
        }
