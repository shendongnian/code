    public class UserViewModel
    {
      puclic string Name { get; set; }
      puclic string LastName { get; set; }
      puclic bool sex { get; set; }
      // and more ...
      public IList<SelectListItem> AvailableCountries { get; set; }
    }
