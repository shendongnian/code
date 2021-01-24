    public partial class Customer {
      private User _creationUser;
      public User CreationUser {
        get {
          if (_creationUser == null) {
            var query = new EntityKeyQuery(new EntityKey(typeof(User), this.CreatedById));
            _creationUser = this.EntityAspect.EntityManager.ExecuteQuery(query).Cast<User>().FirstOrDefault();
          }
          return _creationUser;
        }
        set {
          _creationUser = value;
          this.CreatedById = _creationUser.UserId;
        }
      }
    }
