    public async Task<IHttpActionResult> Put(string id, TeamMemberRequestModel teamMember)
    {
        TIERDBContext IdentityContext = (TIERDBContext)this.TIERUserManager.UserStore().Context;
        foreach (DrivingLicenceCategoryModel DrivingLicenceCategory in teamMember.DrivingLicence.DrivingLicenceCategories)
        {
            if (DrivingLicenceCategory.Id == 0)
            {
                IdentityContext.DrivingLicenceCategories.Add(DrivingLicenceCategory);
            }
            else
            {
                IdentityContext.DrivingLicenceCategories.Attach(DrivingLicenceCategory);
            }
        }
        foreach (DrivingLicencePointModel DrivingLicencePoint in teamMember.DrivingLicence.DrivingLicencePoints)
        {
            if (DrivingLicencePoint.Id == 0)
            {
                IdentityContext.DrivingLicencePoints.Add(DrivingLicencePoint);
            }
            else
            {
                 IdentityContext.DrivingLicencePoints.Attach(DrivingLicencePoint);
            }
        }
		
		this.DetectAddedOrRemoveAndSetEntityState(CurrentTeamMember.DrivingLicence.DrivingLicenceCategories.AsQueryable(),teamMember.DrivingLicence.DrivingLicenceCategories, IdentityContext);
        this.DetectAddedOrRemoveAndSetEntityState(CurrentTeamMember.DrivingLicence.DrivingLicencePoints.AsQueryable(),teamMember.DrivingLicence.DrivingLicencePoints, IdentityContext);
        CurrentTeamMember.ShallowCopy(teamMember);
        await this.TIERUserManager.UpdateAsync(CurrentTeamMember);
    }
