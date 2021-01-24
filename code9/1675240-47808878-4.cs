    public async Task<UserColor> getColorUser(string userNameColor)
        {
            var list = await database
                           .QueryAsync<UserColor>("Select ColorUser From UserColor Where UserName='"+userNameColor+"'")
                           .ConfigureAwait( false );
            return list.FirstOrDefault();       
        }
