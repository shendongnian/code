    public class Contact: IIdDescription
    {
            public int ID { get; set; }
            public string Description { get; set; }
    }
    public class Member: IIdDescription
    {
         public int ID { get; set; }
         public string Description { get; set; }
    }
    public interface IIdDescription
    {
         int ID { get; set; }
         string Description { get; set; }
    }
    public ActionResult GetAll(string type)         
    {
       List<LookupType> AllList = new List<LookupType>();
       if(type == Member.GetType().Name)
          AllList = repo.Set<Member>().Cast<IIdDescription >().ToList();
       if(type == Contact.GetType().Name)
           AllList = repo.Set<Contact>().Cast<IIdDescription >().ToList();
       ...
    }
