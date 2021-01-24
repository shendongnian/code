    public async Task<FreelancerProfileViewModel> GetFreelancerProfile()
    {
        var id = Guid.Parse(_identity.GetUserId());
        var model = await _freelancerProfiles
            .AsNoTracking()
            .Where(_ => _.User.Id == id)
            .ProjectTo<FreelancerProfileViewModel>(_mapper.Configuration)
            .FirstAsync();
     //  var viewmodel =  _mapper.Map<FreelancerProfileViewModel>(model);
        return model;
    }
