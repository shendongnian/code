    public static partial class Ex {
        private static readonly ThreadLocal<CodeModel> _code = new ThreadLocal<CodeModel>();
        public static CodeModel ConvertToModel(Code entity) {
            if (entity == null) return null;
            if (_code.Value != null)
                return _code.Value;
            CodeModel model = new CodeModel();
            _code.Value = model;
            model.Errors = entity.Errors?.SelectShoppingCartProductModel();
            // other setters here
            _code.Value = null;
            return model;
        }
        public static ErrorModel[] SelectShoppingCartProductModel(this IEnumerable<Error> source) {
            bool includeRelations = source.GetType() != typeof(DbQuery<Error>); //so it doesn't call other extensions when we are a db query (linq to sql)
            return source.Select(x => new ErrorModel {
                Code = includeRelations ? ConvertToModel(x.Code) : null,
            }).ToArray();
        }
    }
