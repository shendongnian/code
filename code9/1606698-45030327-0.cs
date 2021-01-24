    public class MongoDevice
    {
       ...
       public ICollection<string> Credentials{ get; set; }
    
       [NotMapped]
       public ReadOnlyCollection<Guid> CredentialIds
       {  // Can be optimized, but requires coding to keep in sync with operations against Credentials...
          get{ return Credentials.Select(x=> Guid.Parse(x)).ToList().AsReadOnly(); }
       }
     }
    
    public class Device 
    {
       ...
       public virtual List<Credential> Credentials{ get; set; }
    }
