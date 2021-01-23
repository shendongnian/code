    public class User
    {
         public int UserId { get; set; }
         public virtual Address HomeAddress { get; set; }
         public virtual int? HomeAddressId { get; set; }
         public virtual ICollection<Address> OfficeAddresses { get; set; }
    }
    
    public class Address
    {
         public int AddressId { get; set; }
         public string AddressLine1 { get; set; } 
    }
    
    public class UserMap : MapEntityTypeConfiguration<User>
    {
         public UserMap ()
         {
            //Other definitions PK etc...
    
            this.HasOptional(o => o.HomeAddress)
                    .WithMany()
                    .HasForeignKey(a => a.HomeAddressId);
            this.HasMany(t => t.OfficeAddresses)
              .WithMany()
              .Map(m =>
              {
                  m.ToTable("UserOfficeAddresses");
                  m.MapLeftKey("AddressId");
                  m.MapRightKey("UserId");
              });
         }
    }
    //and define Address Configurations.. MapEntityTypeConfiguration<Address>
