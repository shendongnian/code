    public async Task<string> GetDescription(int codeId)
        {
            var Codes = await GetAll();
            return Codes.Description;
        }
    
            private async Task<DbSet<Codes>> GetAll()
            {
                return Context.Codes;
            }
