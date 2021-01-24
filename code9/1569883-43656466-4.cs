    public interface IMyObjectRepostory
    {
        IEnumerable<MyObject> GetAll();
        MyObject Add(value1, value2);
    }
    public class MyObjectRepostory
    {
        public IEnumerable<MyObject> GetAll()
        {
            _repository.GetAllObjects();
        }
        MyObject Add(value1, value2)
        {
            var newItem = factory.Create(value1, value2);
            repository.AddObject(newItem);
            return newItem;
        }
    }
