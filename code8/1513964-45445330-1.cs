    public class DataReader
    {
    
        /// <summary>
        ///     Get your list via data manager or something
        /// </summary>
        public List<T> ListItems<T>()
            where T : IStatusIdProperty
        {
            return new List<T>();
        }
    
        public List<T> GetPubItems<T, TView>()
            where T:IStatusIdProperty
            where TView : IStatusIdProperty
        {
            var expression = ConvertExpression<T, TView>(x => x.StatusId == "Pub");
            return ListItems<T>().Where(expression.Compile()).ToList();
        }
    
    
        public Expression<Func<T, bool>> ConvertExpression<T, TView>(Expression<Func<TView, bool>> predicate)
            where T : IStatusIdProperty
            where TView : IStatusIdProperty
        {
            var paramDictionary = predicate.GetParamsDictionary().FirstOrDefault();
            var expression = ExpressionHelper.GetEqualExpression<T>(paramDictionary.Key, paramDictionary.Value);
            return expression;
        }
    
    }
