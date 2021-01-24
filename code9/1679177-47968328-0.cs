    class Program
    {
        public static void Main(string[] args)
        {
            var service = new ModelToViewModelServiceBase();
            new Thread(() => AddServices(service)).Start();
            new Thread(() => AddServices(service)).Start();
            new Thread(() => AddServices(service)).Start();
            new Thread(() => AddServices(service)).Start();
            Console.ReadKey();
        }
        private static void AddServices(ModelToViewModelServiceBase services) {
            for (int i = 0; i < 100000; i++) {
                services.GetViewModel(i);
            }
        }
    }
    public class ModelToViewModelServiceBase {
        private readonly IDictionary<int, string> _modelToViewModel
            = new Dictionary<int, string>();
        protected string Create(int model) {
            return model.ToString();
        }
        public string GetViewModel(int model) {
            if (!_modelToViewModel.ContainsKey(model))
                _modelToViewModel[model] = Create(model);
            return _modelToViewModel[model];
        }
    }
