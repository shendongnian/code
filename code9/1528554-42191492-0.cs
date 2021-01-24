    public static ShoppingCartModel ConvertToModel(ShoppingCart entity)
    {
        if (entity == null) return null;
        ShoppingCartModel model = new ShoppingCartModel
        {
            ...
            Products = entity.ShoppingCartProducts?.SelectShoppingCartProductModel(typeof(ShoppingCart)),
        };
        return model;
    }
