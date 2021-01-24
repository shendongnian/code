    public class FoodItem
    {
        public string FoodCategory { get; set; }
        public string FoodType { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public FoodItem()
        {
            Ingredients = new List<Ingredient>();
        }
        public static FoodItem CreateFromCommaString(string commaSeparatedValues)
        {
            var foodItem = new FoodItem();
            if (string.IsNullOrWhiteSpace(commaSeparatedValues)) return foodItem;
            var values = commaSeparatedValues.Split(',')
                .Select(value => value.Trim()).ToList();
            double price;
            foodItem.FoodCategory = values[0];
            if (values.Count > 1) foodItem.FoodType = values[1];
            if (values.Count > 2) foodItem.Size = values[2];
            if (values.Count > 3 && double.TryParse(values[3], out price))
            {
                foodItem.Price = price;
            }
            
            if (values.Count > 4)
            {
                for (int i = 4; i < values.Count; i += 2)
                {
                    var ingredient = new Ingredient {Name = values[i]};
                    double qty;
                    if (values.Count > i + 1 && double.TryParse(values[i + 1], out qty))
                    {
                        ingredient.Quantity = qty;
                    }
                    foodItem.Ingredients.Add(ingredient);
                }
            }
            return foodItem;
        }
        public override string ToString()
        {
            return string.Format("{0}: {1} ({2}) = ${3:0.00}. Contains: {4}",
                FoodCategory, FoodType, Size, Price, string.Join(", ", Ingredients));
        }
    }
