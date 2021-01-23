    public class Model
    {
        public string Name;
        public double CostValue;
    }
    
    public List<Model> dataSource = new List<Model>()
        {
            new Model()
            {
                Name = "A",
                CostValue = 60
            },
            new Model()
            {
                Name = "B",
                CostValue = 0
            }
        };
    //Price change dictionary maps Name to Price.
    public void PriceChange(Dictionary<string, double> newPrices)
    {
        foreach (Model model in dataSource)
        {
            if (newPrices.ContainsKey(model.Name))
                model.CostValue = newPrices[model.Name];
        }
    }
