    public static partial class Ex {
        public static CodeModel ConvertToModel(Code entity) {
            if (entity == null) return null;
            CodeModel model = new CodeModel();
            var map = new Dictionary<object, object>();
            map.Add(entity, model);
            model.Errors = entity.Errors?.SelectShoppingCartProductModel(map);
            return model;
        }        
        public static ErrorModel[] SelectShoppingCartProductModel(this IEnumerable<Error> source, Dictionary<object, object> map = null) {
            bool includeRelations = source.GetType() != typeof(DbQuery<Error>); //so it doesn't call other extensions when we are a db query (linq to sql)
            return source.Select(x => new ErrorModel {
                Code = includeRelations ? (map?.ContainsKey(x.Code) ?? false ? (CodeModel) map[x.Code] : ConvertToModel(x.Code)) : null,
                // other such entities might be here, check the map
            }).ToArray();
        }
    }
