    public List<string> GetDistinctNames()
    {
        return GetDistinctProperties(product => product.Name.ToLower());
    }
    
    
    public List<string> GetDistinctProperties(Func<Product, string> evaluator)
    {
        return listOfProducts.Select(evaluator).Distinct().ToList();
    }
