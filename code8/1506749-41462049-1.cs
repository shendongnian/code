    public class FakeUserDataService : IUserDataService
    {
        public User DummyUser { get; set; }
        public User GetById(int id) => DummyUser;
    }
