    public class RecipeTypesIndexService : IRecipeTypeIndexService
    {
        private Context context { get; }
        public RecipeTypesIndexService(Context context) : base(context)
        {
            this.context = context;
        }
        public IEnumerable<RecipeType> GetAll()
        {
            return context.RecipeTypes.AsEnumerable();
        }
    }
