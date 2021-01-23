    public UserManager(AppDbContext context, IActiveDirectoryManager activeDirectoryManager)
    {
        _activeDirectoryManager = activeDirectoryManager;
        _userRepository = new Repository<ApplicationUser>(context);
        _applicationRepository = new Repository<Application>(context);
        _roleRepository = new Repository<Role>(context);
    }
