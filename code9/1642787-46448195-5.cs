    public async Task<List<Model>> GetAllByCode(string code)
    {
    	using (var ctx = new DatabaseContext())
    	{
    		var all = await ctx.Models.ToListAsync();
    		var result = all.Where(m => m.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase)));
    		return result;
    	}
    }
