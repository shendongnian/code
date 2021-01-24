    public static class MyRepository // consider not static, just an example
    {
        public static async Task<List<Company>> GetCompanies()
        {
            using (var connection = new Connection()) // consider factory
            {
                return await con.Companies.Where(x => x.IsDeleted == false).ToListAsync();
            }
        }
        public async Task<List<Citizenship>> GetCitizenships()
        {
            using (var connection = new Connection()) // factory?
            {
                return await con.Countries.Select(x => x.Citizenship).Distinct().ToList();
            }
        }
    }
