    public async Task<Character> GetCharacterAsync(Region region, int charId)
    {
        var res = await requester.CreateGetRequestAsync<Dictionary<long, Character>>
                       (bld.BuildUrlForEndpoint("GetCharacter",
                       region, charId.ToString()));
        var obj = res.Values.FirstOrDefault();
        return obj;
    }
