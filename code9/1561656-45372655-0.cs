        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<User,long> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        
        public AccountController(IUnitOfWorkManager unitOfWorkManager,
            IRepository<User,long> userRepository,
            IRepository<Role> roleRepository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        
        public override async Task YourMethod() {
            using (_unitOfWorkManager.Current.SetTenantId(tenant.Id)) {
                     var roles =_roleRepository.GetAll();
                     var users =_userRepository.GetAll();
                 }
        }
