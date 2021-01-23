    public interface IContainer
    {
        // common properties
    }
    
    public class Picture: IContainer
    {
       // prop
    }
    
    public class Parameter: IContainer
    {
       //prop
    }
    
    public class SetupStep
    {
       public ObservableCollection<IContainer> Containers {get; set;}
    }
