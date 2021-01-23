`
public class EmailModel
{
    public EmailModel()
    {}
    public EmailModel(string _name, string _company)
    {
        Name = _name;
        Company = _company;
    }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public string Phone { get; set; }
    public string Additional { get; set; }
}
`
Fixed by removing all but one constructor like this:
`
public class EmailModel
{
    public EmailModel()
    {}
    public string Name { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public string Phone { get; set; }
    public string Additional { get; set; }
}
`
