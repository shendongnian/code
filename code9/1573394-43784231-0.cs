    [HttpGet]
    [AllowAnonymous]
    [EnableBreezeQuery(MaxExpansionDepth = 0)]
    public IQueryable<Network> NetworkForEntryPageBy()
    {
      return _unitOfWork.NetworkRepository.All();
    }
