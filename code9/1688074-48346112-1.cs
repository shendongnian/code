    public class TestDbContextBuilder<TDbContextInterface> where TDbContextInterface : class
    {
        public TDbContextInterface Build()
        {
            var mock = new Mock<TDbContextInterface>();
            mock.SetupAllProperties();
    
            var dbSetProps = typeof(TDbContextInterface).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                                        .Where(pi => pi.PropertyType.IsGenericType &&
                                                                     pi.PropertyType.GetGenericTypeDefinition() ==
                                                                     typeof(DbSet<>));
            foreach (var prop in dbSetProps)
            {
                var dbSetType = prop.PropertyType;
                var dbSetGenericType = dbSetType.GetGenericArguments()[0];
    
                var testDbSetType = typeof(TestDbSet<>).GetGenericTypeDefinition().MakeGenericType(dbSetGenericType);
                var testDbSetInstance = Activator.CreateInstance(testDbSetType);
    
                prop.SetValue(mock.Object, testDbSetInstance);
                }
    
            return mock.Object;
        }
    }
