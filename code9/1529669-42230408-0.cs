    public class SoftwareSession : ISoftwareSession
    {
        IRepository repository;
        public SoftwareSession(IRepository repository)
        {
            this.repository = repository;
        }
        public void WriteCar(Car car)
        {
            repository.WriteCar(car);
        }
    }
