        public class UserListDecorator : IEnumerable<User>
    {
        private IEnumerable<User> users;
        public UserListDecorator(IEnumerable<User> users)
        {
            this.users = users;
        }
        public IEnumerator<User> GetEnumerator()
        {
            var innerList = users.ToList();
            innerList.Add(new User() {LastName = "New User", Id = 0});
            return innerList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
