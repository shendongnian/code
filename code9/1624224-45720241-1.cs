    public class DerivedService : IService<MyModel>
    {
        public List<MyModel> GetEmployeeDetails()
        {
            return _connection.Table<MyModel>().ToList(); 
        }
    }
