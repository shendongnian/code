    var allTheVendorsDeserialized = JsonConvert.DeserializeObject<AllTheVendors>(responseFromServer);
    public class AllTheVendors {
    
        public bool Success {get;set}
        public List<Vendor> {get;set}
    }
