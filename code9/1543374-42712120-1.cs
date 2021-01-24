    foreach (string memberSid in member.Members)
    {
          Identity memberInfo = sec.ReadIdentity(SearchFactor.Sid, memberSid, QueryMembership.Expanded);
          if (memberInfo.Type == IdentityType.WindowsUser && memberInfo.Domain == "DomainName")
          {
                                    result.Add(new TfsPermission
                                    {
                                        Collection = tfsProjectCollection.Name,
                                        TeamProject = teamProject.Name,
                                        User = memberInfo.AccountName,
                                        Domain = memberInfo.Domain,
                                        Group = group.DisplayName
                                    });
           }
    }
