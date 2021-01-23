    var buyerProfiles = _profileService.GetAllBuyerProfiles();
    var producerProfiles = _profileService.GetAllProducerProfiles();
    var combinedProfiles = 
        from bp in buyerProfiles
        join pp in producerProfiles on bp.UserId equals pp.UserId
        select new BuyerProducerprofile()
        {
            UserId = pp.UserId, 
            BuyerName = bp.Name,
            ProducerName = pp.Name 
        }
