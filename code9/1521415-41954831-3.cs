    public async Task<List<UserDto>> GetUsers(UserRequestDto dto)
    {
        using (var _client = GetClientInstance())
        {              
            // do stuff
            var users = await _client.GetAsync("url here");
        }
    }
