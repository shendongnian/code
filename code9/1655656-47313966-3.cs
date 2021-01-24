    static void Main(string[] args)
            {
                using (var db = new Database("PetaExample"))
                {
                    try
                    {
                        var Administrators = new Administrators
                        {
                            Name = "Mami",
                            SurName = "Dora",
                        };
                        
                        db.Insert("mdpub.Administrators", "dbid", true, Administrators);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
    
                Console.ReadKey();
            }
            
    
        }
        public class Administrators
        {
            public int dbid { get; set; }
            public string Name { get; set; }
            public string SurName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
    
        }
