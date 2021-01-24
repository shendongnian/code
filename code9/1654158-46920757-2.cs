    public class RecipeComponent
    {
        public  string Material { get; set; }
        public  int Count { get; set; }
        public RecipeComponent(string material, int count)
        {
            Material = material;
            Count = count;
        }
    }
