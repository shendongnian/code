    public class Job : IEntityBase
    {
       public int Id { get; set; }
       public ICollection<Client> Clients{ get; set; }
    }
