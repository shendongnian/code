    public Task<Either<Exception, int>> Issue207() =>
        Initialization
            .BindT(createUserMapping)
            .BindT(addUser);
    static Task<Either<Exception, ADUser>> Initialization =>
        Right<Exception, ADUser>(ADUser.New("test user")).AsTask();
    static Either<Exception, UserMapping> createUserMapping(ADUser user) =>
        Right<Exception, UserMapping>(UserMapping.New(user.ToString() + " mapped"));
    static Task<Either<Exception, int>> addUser(UserMapping user) =>
        Right<Exception, int>(user.ToString().Length).AsTask();
