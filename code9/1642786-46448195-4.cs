    public async Task<List<Model>> GetAllByCode(string code)
    {
    	using (var ctx = new DatabaseContext())
    	{
    		return await ctx.Models.Where(m => m.Code.ToLower() == code.ToLower()).ToListAsync();
    	}
    }
