    public class BillReport : IReport {
        Func<Type, bool> typeisIPdf = (type) => typeof(BillModel).IsAssignableFrom(type);
        Func<Type, bool> typeisIPdfCollection = (type) => typeof(IEnumerable<BillModel>).
        IsAssignableFrom(type);
        private readonly IBusinessLogic _logic;
        public BillReport(IBusinessLogic logic) {
            this._logic = logic;
        }
        public bool CanHandle(object model) {
            if (model == null) return false;
            var type = model.GetType();
            return typeisIPdf(type) || typeisIPdfCollection(type);
        }
        public Task<MemoryStream> Create(object model) {
            var stream = new MemoryStream();
            if (CanHandle(model.GetType())) {
                //...Pdf generation code
                //call data update
                _logic.update(model);
            }
            return Task.FromResult(stream);
        }
    }
    public class PurchaseReport : IReport {
        Func<Type, bool> typeisIPdf = (type) => typeof(PurchaseModel).IsAssignableFrom(type);
        Func<Type, bool> typeisIPdfCollection = (type) => typeof(IEnumerable<PurchaseModel>).
        IsAssignableFrom(type);
        private readonly IBusinessLogic _logic;
        public PurchaseReport(IBusinessLogic logic) {
            this._logic = logic;
        }
        public bool CanHandle(object model) {
            if (model == null) return false;
            var type = model.GetType();
            return typeisIPdf(type) || typeisIPdfCollection(type);
        }
        public Task<MemoryStream> Create(object model) {
            var stream = new MemoryStream();
            if (CanHandle(model.GetType())) {
                //...Pdf generation code
                //call data update
                _logic.update(model);
            }
            return Task.FromResult(stream);
        }
    }
