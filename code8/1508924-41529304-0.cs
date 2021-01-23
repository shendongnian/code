        using System.Linq;
        using System.Data;
        using System.Data.Linq;
        using System.Data.Linq.Mapping;
        namespace ...
        {
                class Program
                {
                    static void Main(string[] args)
                    {                    
                        DataContext dataContext = new DataContext(connectionString);
                        Table<Email> Emails = dataContext.GetTable<Email>();
                        IQueryable<string> query = from e in Emails
                                                   select $"email: {e.email}";
            
            
                    }
                }
            
                [Table]
                public class Email
                {
                    [Column(IsPrimaryKey = true)]
                    public string email;
                }
         }
