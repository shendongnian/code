    public static class Extensions
    {
        public static IQueryable<MyModelVM> SelectVMs(this IQueryable<MyModel> models)
        {
            return models.Select(x => new MyModelVM { MyModelId = x.MyModelId });
        }
    }
