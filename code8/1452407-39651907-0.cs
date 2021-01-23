    public class Controller
    {
        public readonly Repository repository;
    
        public Controller(Repository repository)
        {
            this.repository = repository;
        }
        
        public void SomeMethod()
        {
            this.repository.AMethodInTheRepository();
        }
    }
