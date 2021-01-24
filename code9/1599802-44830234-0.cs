    public IActionResult SaveNewClaim(NewClaimViewModel newClaim)
    {
        if (newClaim.TakeUpDate == "")
        {
            ModelState.Remove("TakeUpDate");
        }
        if (ModelState.IsValid)
        {
            newClaim.TakeUpDate = null;
            _claimsRepository.Insert(_newClaimViewModelToClaimConverterService.Convert(newClaim));
            return CreateJsonResult(true, "Az igény sikeresen lementésre került");
        }
        return CreateJsonResult(false, GetErrorMessages());
    }
