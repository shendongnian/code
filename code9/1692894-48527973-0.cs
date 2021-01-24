    public class Client
    {
    public int Id { get; set; }
    public string Name{ get; set; }
    public string Lastname{ get; set; }
    public int DNI { get; set; }
    public List<Phones> Phones{ get; set; }
    }
    public class Phone
    {
    [Key]
    public int IdPhone { get; set; }
    public int Number{ get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    }
    public Client Create(Client client)
    {
    if (_context.Client.Any(x => x.DNI == cliente.DNI))
        throw new AppException("Username " + cliente.DNI + " is already taken");
    _context.Client.Add(client);
    _context.SaveChanges();
    return client;
    }
