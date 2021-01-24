    public static class RepoExtensions
    {
      private static readonly euCountries = new Country[]{};
      public static IEnumerable<ICountryOfOrigin> GetEU(this Repository repo)
      {
        return repo.Products.GetAll().Where(p=> euCountries.Contains(p.countries);
      }
    }
