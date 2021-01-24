    var providerroles = AppConstants.ProviderRolesonly.Split(',').ToArray();
                List<int> providerroleIds = new List<int>();
                foreach (var id in providerroles)
                {
                    providerroleIds.Add(rolesService.GetWhere(a => a.RoleName == id).Select(a => a.Id).First());
                }
    
     List<int> roleidprovider = providerroleIds; 
