    public class ProductionSummaryObservable
    {
        static Subject<Dictionary<SimpleRessourceEnum, int>> _subject;
        IBuildingsService _buildingService;
        IProductionService _productionService;
        private static readonly object lockObject = new object();
        protected Subject<Dictionary<SimpleRessourceEnum, int>> Subject
        {
            get
            {
                lock (lockObject)
                {
                    if (_subject == null)
                    {
                        _subject = new Subject<Dictionary<SimpleRessourceEnum, int>>();
                        var observables = _buildingService.GetProductionBuildings()
                            .Select(x => new { Level = x.Level, ProducedResource = x.ProducedResourceId })
                            .ToList();
                        Observable.Merge(observables
                            .Select(x => x.Level.AsObservable()))
                            .Subscribe(_ => _subject.OnNext(_productionService.GetProductionSummary()));
                        Observable.Merge(observables
                            .Select(x => x.ProducedResource.AsObservable()))
                            .Subscribe(_ => _subject.OnNext(_productionService.GetProductionSummary()));
                    }
                }
                return _subject;
            }
        }
        public ProductionSummaryObservable(IBuildingsService buildingService, IProductionService productionService)
        {
            _buildingService = buildingService;
            _productionService = productionService;
        }
        public IObservable<int> ProductionSummaryByResourceObservable(SimpleRessourceEnum resource)
        {
            return Subject.Select(x => x.First(y => y.Key == resource).Value);
        }
    }
