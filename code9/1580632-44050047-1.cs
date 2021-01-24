    static void Main(string[] args)
    {
        using (DataClasses_LOG01DataContext log01 = new DataClasses_LOG01DataContext(ConfigurationManager.ConnectionStrings["conn_log"].ConnectionString))
        {
            var list = log01.name_numbers
                .Select(x => x.name.Replace(".", "") + "_" + x.number))
                .BatchesOf(1000)
                .ToList();
    
            using (DataClasses_SQL01DataContext sql01 = new DataClasses_SQL01DataContext(ConfigurationManager.ConnectionStrings["conn_sql"].ConnectionString))
            {
                list.ForEach(batch => {
                   var log = sql01.names.Select(x => x.name);
                   var missing = log.Where(x => !batch.Contains(x.name));
    
                   foreach (var item in missing)
                   {
                      string[] result = item.ToString().Split('_');
                      Console.WriteLine("{0} {1}", result[0], result[1]);
                   }
                });
                
            }
        }
    }
