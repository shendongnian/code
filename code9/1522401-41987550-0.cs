     Hi I tried with same structure in EF 6.1.3 version and it worked like charm .I added image of output and data present in db .The only thing that might stoped working if you disable loading in configuration . I hope it work for you please try my sample code .
      // Your entity class I added name property to show you the results 
       public class MyList
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public long MyListId { get; set; }
            public long? ParentMyListId { get; set; }
            public string Name { get; set; }
            [ForeignKey("ParentMyListId")]
            public virtual MyList MyListParent { get; set; }
            public virtual ICollection<MyList> MyListChildren { get; set; }
        }       
         // DBContext please note no configuration properties set just default constructor you need t check here if you have set soemthing here 
           public class TestContext : DbContext
            {
                public TestContext()
                    : base("name=TestConnection")
                {
                }               
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<MyList>()
                    .ToTable("MyList", "dbo")
                    .HasOptional(x => x.MyListParent)
                    .WithMany(x => x.MyListChildren)
                    .HasForeignKey(x => x.ParentMyListId)
                    .WillCascadeOnDelete(false);
                }
                
                public virtual DbSet<MyList> Lists { get; set; }
            }
