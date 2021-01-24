    public class PersonDTO
    {
        public string FirstName { get; set; }
    }
    dataContext
        .User
        .Where(n => n.FirstName.Contains(search))
        .Select(x => new PersonDTO { FirstName = x.FirstName })
        .ToList();
