    public class TestWebApiResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            return new[] { typeof(EmployeesController).Assembly };
        }
    }
