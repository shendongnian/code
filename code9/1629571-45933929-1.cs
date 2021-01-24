    //provided by DI
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
    //or
    //using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete))
    {
        var completelyAllUsers = _userRepository.GetAllList();                
    }
