        class Program
        {
        
            static void Main(string[] args)
            {
                Run().Wait();
    
            }
            static async Task Run()
            {
                var constr = "server=localhost;database=tempdb;integrated security=true";
                var sql = @"
    set nocount on;
    select newid() d
    into #foo
    from sys.objects, sys.objects o2, sys.columns 
    order by newid();
    select count(*) from #foo;
    ";
    
                using (var rdr = await SqlCommandWithProgress.ExecuteReader(constr, sql, s => Console.WriteLine(s)))
                {
                    if (!rdr.IsClosed)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Row read");
                        }
                    }
                }
                Console.WriteLine("Hit any key to exit.");
                Console.ReadKey();
        
                
            }
        }
