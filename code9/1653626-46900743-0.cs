    public class SearchContaPagarReceberModel {
        public IPagedList<ContaPagarReceberModel> lista { get; set; }
        // this property will be passed to view instead of 'lista' above
        public List<ContaPagarReceberModel> ContaPagarReceberModels { get; set; }
        // other properties
    
        public SearchContaPagarReceberModel() { }
    }
