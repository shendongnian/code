    var query = await (from contracts in DbContext.CHPContracts
                                   join organisation in DbContext.Organisations on contracts.END_USER_ORG equals organisation.End_User_Org into organisation_joined
                                   where request.ContractRefRequests.Contains(contracts.CONTRACT_REF)
                                   from oj in organisation_joined.DefaultIfEmpty()
                                   from contacts in oj.CHPContacts.DefaultIfEmpty()
                                   select new UserDto
                                   {
                                       Email = contacts.Email,
                                       FirstName = contacts.FirstName,
                                       LastName = contacts.LastName,
                                       ID = contacts.ID,
                                       SMS = contacts.Mobile,
                                       Status = contacts.Status,
                                       UserID = "",
                                       UserRole = "",
                                       OrgID = contacts.OrgId,
                                       OrganisationName = oj.OrganisationName,
                                       End_User_Org = oj.End_User_Org
                                   }).ToListAsync();
