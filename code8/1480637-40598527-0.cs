    public UserManager(IRepository<ApplicationUser> userRepository, IRepository<Application> applicationRepository, IRepository<Role> roleRepository, IActiveDirectoryManager activeDirectoryManager)
    {
        _activeDirectoryManager = activeDirectoryManager;
        _userRepository = userRepository;
        _applicationRepository = applicationRepository;
        _roleRepository = roleRepository;
    }
