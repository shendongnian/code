    public int Id { get; set; }
    public string PersonName { get; set; }
    public string PersonLastName { get; set; }
    public string PersonPatronymic { get; set; }
    public ICollection<PersonsSignsHair> PersonsSignsHair { get; set; }
    public ICollection<PersonsSignsBodyType> PersonsSignsBodyType { get; set; }
