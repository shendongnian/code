    public class CommonEntity{
         [key]
         public int CID{get;set;}
         
         public long AddressId { get; set; }
         
         [ForeignKey("Address")]
         public virtual List<Address> Addresses { get; set; }
    }
    public class Address{
         [key]
         public int AddressID{get;set;}
         public string country{get;set;}
         public virtual ICollection<CommonEntity> CommonEntity { get; set; }
    }
    [Table("Licensee")]
    public class Licensee{
         public string CompanyName{get;set;}
    }
    [Table("User")]
    public class User{
         public string UserName{get;set;}
         public string Pass{get;set;}
    }
