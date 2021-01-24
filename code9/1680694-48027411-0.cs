    //Declarations of Lists
    
    public List<ResourceTemplate> stockpile = new List<ResourceTemplate>();
    
    //We pass to the obj a name and creates the obj with the name and a 
    stockpile
    
    public NationBuilder(string name)
            {
                this.Name = name;
                
                stockpile = new List<ResourceTemplate>();}
    //We can add resources into the stockpile with LINQ
    public void AddResource(string itemName, int quantity,  float value)//Adds 
    Resources to the stockpile
        {
         stockpile.Add(new ResourceTemplate {Name = itemName, Quantity = 
         quantity, Value = value });
        }
