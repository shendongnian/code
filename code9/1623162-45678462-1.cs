    public string GetProductFromView(string conceptOrder)
    {
        int[] ConceptOrder = conceptOrder.Split(',').Select(x=>Convert.ToInt32(x)).ToArray();
        string[] Properties = new string[] {Warehouse,Commodity,Variety,Packstyle,Size};
        return string.Join(" ", ConceptOrder.Select(x=>Properties[x]));
    }
