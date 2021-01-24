    public class MyObjectChooseBetterName
    {
        private readonly IMyObjectRepository _repository;
        private readonly MyObjectFactory _factory;
        public MyObjectChooseBetterName(IMyObjectRepository repository,
                                        MyObjectFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }
        public MyObject CreateAndSave(object value1, object value2)
        {
            var newObject = _factory.Create(value1, value2);
            _repository.Add(newObject);
            return newObject;
        }
    }
