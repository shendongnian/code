    public async Task<IEnumerable<UserDto>> GetUsersInParallel(IEnumerable<int> userIds)
    {
        var tasks = userIds.Select(id => client.GetUser(id));
        var users = await Task.WhenAll(tasks);
 
        return users;
    } 
    public async Task<UserDto> GetUser(int id)
    {
        var response = await client.GetAsync("http://youraddress/api/users/" + id)
            .ConfigureAwait(false);
        var user = JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());
 
        return user;
    }
