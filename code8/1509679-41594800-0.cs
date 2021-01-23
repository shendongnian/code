    foreach (var id in guids)
    {    
		if (_memberInterestService.IsSubInterestExist(id))
        {
			_memberInterestService.Delete(id, item.Id, true);
		}	
		else if (!_memberInterestService.IsSubInterestExist(id))
		{
			_memberInterestService.Add(new MemberInterestDto
				{
					UserProfileId = item.Id,
					InterestSubCategoryId = id
				});
		}
        else
		{
            _memberInterestService.Delete(id, item.Id, false);
		}
    }
