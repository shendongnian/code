    .Field(nameof(Toppings),
        validate: async (state, value) =>
        {
            var values = ((List<object>)value).OfType<ToppingOptions>();
            var notInStock = GetOutOfStockToppings(values);
            
            if(notInStock.Any())
                return new ValidateResult { IsValid = false, Value = null, Feedback = $"These are not in stock: {string.Join(",", notInStock.ToArray())} Please choose again." };
    
            return new ValidateResult { IsValid = true, Value = values};
        })
    static IEnumerable<ToppingOptions> NotInStock = new[] { ToppingOptions.Lettuce, ToppingOptions.Pickles };
    private static IEnumerable<ToppingOptions> GetOutOfStockToppings(IEnumerable<ToppingOptions> toppings)
    {
        List<ToppingOptions> result = new List<ToppingOptions>();
        foreach(var topping in toppings)
        {
            if (NotInStock.Contains(topping))
                result.Add(topping);
        }
        return result;
    }
