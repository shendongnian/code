    var sourceSystems = 
        this.TxtCreateAgencySourceSystem
            .Text
            .Split(',')
            .Select(source => source.Trim())
            .Where(source => string.IsNullOrWhiteSpace(source) == false)
            .Select(source => new Governance
            {
                AgencyCode = $"{AgencyCode}_{source},
                GovernanceCode = ${AgencyCode}_{source}_{Constants.GOVERNANCE_ROLE_DATA_OWNER_VALUE}",
                RoleCode = Constants.GOVERNANCE_ROLE_DATA_OWNER_VALUE,
                CreatedBy = EDHSession.Current.User.EmailAddress,
                CreatedDate = dateTimeNow
            })
            .Select(governance => new
            {
                Governance = governance,
                IsAdded = userServiceProxy.CreateGovernance(governance)
            })
            .ToList() // here all Selects and Wheres methods will be executed actually
    var addedSystems = sourceSystems.Where(system => system.IsAdded)
                                    .Select(system => system.Covernance)
                                    .ToArray();
