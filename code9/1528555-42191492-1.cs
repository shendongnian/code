    public static partial class Ex
    {
        public static IEnumerable<ShoppingCartProductModel> SelectShoppingCartProductModel(this IEnumerable<ShoppingCartProduct> source, Type objSource = null)
        {
            bool includeRelations = source.GetType() != typeof(DbQuery<ShoppingCartProduct>);//so it doesn't call other extensions when we are a db query (linq to sql)
            return source.Select(x => new ShoppingCartProductModel
            {
                ....
                ShoppingCart = includeRelations && objSource != typeof(ShoppingCart)  ? ShoppingCartRepository.ConvertToModel(x.ShoppingCart) : null,
            });
        }
    }
