    //1 - create a List<T> with test items
    var users = new List<UserEntity>()
    {
     new UserEntity,
     ...
    };
    //2 - build mock by extension
    var mock = users.AsQueryable().BuildMock();
    //3 - setup the mock as Queryable
    _userRepository.Setup(x => x.GetQueryable()).Returns(mock.Object);
