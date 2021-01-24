    public static async Task<List<DataModel>> GetListAsync()
    {
       await Task.Delay(500);
       var list = new List<DataModel>
       {
            new DataModel() { Name = "me", City = "Atlantis" },
            new DataModel() { Name = "you", City = "Timbuktu" }
       };
       return list;
    }
    
    public static List<DataModel> GetList()
    {
        var list = new List<DataModel>
        {
            new DataModel() { Name = "me", City = "Atlantis" },
            new DataModel(0 { Name = "you, City = "Timbuktu" }
        }
        return list;
    }
