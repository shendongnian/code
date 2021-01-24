    public class ModelNameResolver : IValueResolver<Product, ProductViewModel, string>
    {
        private readonly InventoryService _inventoryService;
        public ModelNameResolver(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        public string Resolve(Product source, ProductViewModel destination,
           string destMember, ResolutionContext context)
        {
            var modelId = source.ModelId;
            if (!modelId.HasValue)
                return "n/a";
            return _inventoryService.GetModel(modelId.Value).Name;
        }
    }
