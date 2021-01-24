    async private static void ServeBreakfast(Diner diner)
    {
        // first task is to get the order
        Task<Order> getOrder = ObtainOrderAsync(diner);
        // we need to wait for the order, then we 
        // can get the ingredients and recipe in parallel
        Order order = await getOrder;
        Task<Ingredients> getIngredients = ObtainIngredientsAsync(order);
        Task<Recipe> getRecipe = ObtainRecipeAsync(order);
        // once we have both the above we can make the meal
        Ingredients ingredients = await getIngredients;
        Recipe recipe = await getRecipe;
        Task<Meal> getMeal = recipe.PrepareAsync(ingredients);
        
        // when the meal is ready, give it to the diner
        diner.Give(await getMeal);
    }
