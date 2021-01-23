    public class Recipe
    {
        public Recipe(Type foodType, params object[] ingredients)
        {
            if (!foodType.IsSubclassOf(typeof(Food)))
            {
                throw new ArgumentException($"{nameof(foodType)} must be a subclass of {nameof(Food)}.");
            }
        }
    }
