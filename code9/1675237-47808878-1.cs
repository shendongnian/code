    public Task<UserColor> getColorUser(string userNameColor)
        {
            retur database.QueryAsync<UserColor>("Select ColorUser From UserColor Where UserName='"+userNameColor+"'")
                              .ToList()
                              .FirstOrDefault();       
        }
