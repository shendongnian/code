    public class ViewModel
    {
        public ViewModel(IService service)
        {
            _service = service;
        }
        private IService _service;
        public int Id { get; set; }
        public string Name { get; set; }
    }
