    // DTO class for projection
    public class PersonDTO
    {
        public string FirstName { get; set; }
    }
    // correct query
    List<PersonDTO> allSearch = dataContext
        .User
        .Where(n => n.FirstName.Contains(search))
        .Select(x => new PersonDTO { FirstName = x.FirstName })
        .ToList();
