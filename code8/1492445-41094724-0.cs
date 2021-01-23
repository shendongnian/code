    public static class CountryRepository
    {
        public static IEnumberable<Country> GetCountriesByContinent(this IRepository<Country> repo, string continent)
        {
            return repo.Where(c => c.Continent == continent);
        }
    }
