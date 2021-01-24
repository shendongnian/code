    public T GetFactory<T>() where T : IFactory
    {
        var t = typeof(T);
        if (t.Equals(typeof(IRecipeFactory)))
        {
            IFactory factory = new RecipeFactory();
            return (T)factory;
        }
        if (t.Equals(typeof(IItemFactory)))
        {
            IFactory factory = new ItemFactory();
            return (T)factory;
        }
        if (t.Equals(typeof(ITileFactory)))
        {
            IFactory factory = new TileFactory();
            return (T)factory;
        }
        throw new InvalidOperationException("Type not supported");
    }
