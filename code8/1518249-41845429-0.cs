    class Recipe 
    {
        public string name { get; set; }
        public List<string> ingredients { get; set; }
        // ... other things the class needs
    }
    
    class MyCookbook 
    {
        public Dictionary<string, List<Recipe>> categories = new Dictionary();
        // Creating a single recipe and giving it ingredients
        var penne = new Recipe();
        penne.name = "Penne";
        penne.ingredients = new List<string>();
        penne.ingredients.add("Tomato Sauce");
        // ... add other ingredients
        // Creating a list of recipes we will associate with some category
        var typesOfPasta = new List<Recipe>();
        typesOfPasta.add(penne);
        // Putting that list of recipes into a category, this time "Pasta"
        categories.add("Pasta", typesOfPasta);
    }
