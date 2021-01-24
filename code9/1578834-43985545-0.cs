    public class Recipe
    {
        public string recipeName;
        public string recipeType;
        public List<string> recipeIngridients = new List<string>();
    
        public Recipe readOne(string name)
        {
            CookBook newCB = new CookBook();
            List<Recipe> allRecipies = newCB.readAll();
            foreach(Recipe oneRecipe in allRecipies)
            {
                if(oneRecipe.recipeName == name)
                {
                    return oneRecipe;
                }
            }
            return newCB.defaultRecipe;
        }
    }
    
    public class RecipeList
    {
        public List<Recipe> Recipes = new List<Recipe>();
    }
    
    public class CookBook
    {
        public Recipe defaultRecipe; 
        public string path;
    
        public void Save(Recipe newRecipe) 
        {
            TextWriter writer = null;
            RecipeList recipeList = null;
            try
            {
                // See if recipes exists
                var serializer = new XmlSerializer(typeof(RecipeList));
                if (File.Exists(path)) // Load the recipe list if it exists
                {
                    using (var fileStream = File.OpenRead(path))
                    {
                        recipeList = (RecipeList)serializer.Deserialize(fileStream);
                    }
                }
                else
                {
                    recipeList = new RecipeList();
                }
                    
                // Add recipe to the list
                recipeList.Recipes.Add(newRecipe);
                writer = new StreamWriter(path, append: false);
                serializer.Serialize(writer, recipeList);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    
        public List<Recipe> readAll()
        { 
            RecipeList temp = null;
            var serializer = new XmlSerializer(typeof(RecipeList));
            try
            {
                using (var fileStream = File.OpenRead(path))
                {
                    temp = (RecipeList)serializer.Deserialize(fileStream);
                }
                return temp.Recipes;
            }
            catch (Exception e)
            {
                string error = @"An exception occured: " + e;
                //Log theLog = new Log();
                //theLog.LogMessage(error);
                return new List<Recipe>();
            }
        }
    }
