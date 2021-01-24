     public class MyRepository
     {
        private readonly IAddMethod<UserAdd> _addMethod;
        private readonly IConnectionFactory _connectionFactory;
        public MyRepository(IAddMethod<UserAdd> userAddMethod, 
          IConnectionFactory connectionFactory) 
        {
           //..guard clauses, assignments, etc.
        }
        public async Task<int> AddAsync(UserAdd user)
        {
            return _addMethod.AddAsync(user);
        }
     }
