    public class PizzaIngredientResolver : ValueResolver<Pizza, bool>
    {
        protected override bool ResolveCore(Pizza src)
        {
            return !string.IsNullOrEmpty(src.Ingredients) && src.Ingredients.Count() != 0;
        }
    }
