    public class ChildViewModel //doesn't inhert from the base view model
    {
        public ChildViewModel()
        {
            var sharedViewModel = Container.Resolve<ApplicationViewModel>();
            //call any properties or methods of the sharedViewModel...
        }
    }
