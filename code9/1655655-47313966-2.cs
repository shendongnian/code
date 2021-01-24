     static void Main(string[] args)
            {
                using (var db = new Database("PetaExample"))
                {
                    try
                    {
                        var result = db.Query<Administrators>("select * from mdpub.Administrators").ToList();
                        
                        result.ForEach(ShowPerson);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
    
                Console.ReadKey();
            }
    
            private static void ShowPerson(Administrators admin)
            {
                Console.WriteLine("{0} {1} ", admin.Name, admin.SurName);
            }
