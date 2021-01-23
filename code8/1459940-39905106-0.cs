    class FluentNHibernateTest
    {
        private static ISessionFactory CreateSessionFactory()
        {
           //also MsSqlConfiguration.MsSql2005 is working
            return Fluently.Configure()
                    .Database(
                        MsSqlConfiguration.MsSql2012.ShowSql()
                            .ConnectionString(x => x.FromConnectionStringWithKey("test16")))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                    .BuildSessionFactory();
        }
        public static string GetSqlVersion()
        {
            string sql = "select @@version version";
            var sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                var query = session.CreateSQLQuery(sql);
                var result = query.UniqueResult();
                Console.WriteLine(result);
                return result.ToString();
            }
        }
    }
 
