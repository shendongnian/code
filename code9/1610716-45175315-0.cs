    [HttpPost("GetOrganisations")]
    public async Task<IActionResult> GetOrganisations([FromBody] GetOrganisationsModel model)
    {
        var organisations = 
            await  _organisationService.GetOrganisations(model?.Id, model?.StatusIds);
    
        var organisationTotalCount = await _organisationService.GetOrganisationCount();
    
        return Ok(new OrganisationViewModel
        {
            Organisations = organisations,
            OrganisationTotalCount = organisationTotalCount
        });
    }
