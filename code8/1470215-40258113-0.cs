    public class EmployeeRepository
    {
        var optionsBuilder = new DbContextOptionsBuilder<effMercContext>();
        // add necessary options
        public Employee GetByID(int id)
        {
            using (effMercContext db = new effMercContext(optionsBuilder.Options))
            {
    
            }
        }
    }
