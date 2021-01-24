    var SourceSystemToBeInserted = 
        this.TxtCreateAgencySourceSystem
            .Text
            .Split(',')
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToArray();
    var agencySourceSystemDataOwnerToBeInsertedIntoGovernance = 
        SourceSystemToBeInserted .Select(AgencySourceSystemToBeInserted => new Governance
        {
            AgencyCode = $"{AgencyCode}_{AgencySourceSystemToBeInserted},
            GovernanceCode = ${AgencyCode}_{AgencySourceSystemToBeInserted}_{Constants.GOVERNANCE_ROLE_DATA_OWNER_VALUE}",
            RoleCode = Constants.GOVERNANCE_ROLE_DATA_OWNER_VALUE,
            CreatedBy = EDHSession.Current.User.EmailAddress,
            CreatedDate = dateTimeNow
        })
        .Select(agencyGovernance => new
        {
            Governance = agencyGovernance,
            IsAdded = userServiceProxy.CreateGovernance(agencyGovernance)
        })
        .ToList() // Important
