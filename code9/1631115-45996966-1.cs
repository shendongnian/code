    public async Task<WhateverSIs> populateEntity(WhateverSIs s)
    {
        s.Entity = await parser.GetSiteDataAsync(s.Entity).ConfigureAwait(false);
        return s;
    }
