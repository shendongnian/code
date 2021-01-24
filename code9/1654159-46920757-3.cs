     static void UpdateCount(string recipeKey, string mName, int updateCount)
        {
            var recipe = _recipes.FirstOrDefault(kv => kv.Key == recipeKey);
            if (recipe.Value != null)
            {
                var material = recipe.Value.FirstOrDefault(m => m.Material == mName);
                if (material != null)
                {
                    material.Count += updateCount;
                }
            }
        }
 
