	public static string GetSpecificRecipeValue(string recipeName, int index, int ingredientIteration = -1, int ingredientValue = -1)//From CurrentRecipeList get value(Index) where recipeName is equal to CurrentRecipeList.RecipeName.
	{
		Func<Recipe, string>[] properties = new Func<Recipe, string>[]
		{
			el => el.RecipeType,
			el => el.RecipeName,
			el => el.RecipeSource,
			el => el.RecipeID,
			el => el.RecipePicture,
			el => el.RecipeDescription,
			el => el.RecipeMethod,
			el => el.RecipeCost,
			el => el.RecipeDifficulty,
			el => el.RecipeServings,
			el => el.RecipePreparationTime,
			el => el.RecipeCookingTime,
			el => el.RecipeGlobalRating,
			el => el.RecipeUserRating,
			el => el.RecipeTags,
		};
	
		Func<Recipe, string>[] ingredients = new Func<Recipe, string>[]
		{
			el => el.RecipeIngredients[ingredientIteration].Item,
			el => el.RecipeIngredients[ingredientIteration].Quantity,
			el => el.RecipeIngredients[ingredientIteration].Unit,
			el => el.RecipeIngredients[ingredientIteration].State,
			el => el.RecipeIngredients[ingredientIteration].Type,
		};
		
		return
			currentRecipeList
				.Where(el => recipeName == el.RecipeName)
				.Select(el =>
					index < 15
						? properties[index](el)
						: ingredients[ingredientValue](el))
				.FirstOrDefault();
	}
