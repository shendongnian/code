    public class FoodItem
    {
       public string FoodCategory {get;set;}
       public string FoodType {get;set;}
       public string Size {get;set;}
       public double Price {get;set;}
       public List<Ingredient> Ingredients {get;set;}
    }
    public class Ingredient
    {
       public string Name {get;set;}
       public int Quantity {get;set;}
    }
