    public class ModelBViewModel
    {
        private ModelB _model;
        public ObservableCollection<ModelCViewModel> CVms { get; set; }
        public ModelBViewModel(ModelB model) {
            _model = model;
            CVms = new ObservableCollection();
            foreach(var modelC in model.Cs) {
                CVms.Add(new ModelCViewModel(modelC));
            }
        }
    }
