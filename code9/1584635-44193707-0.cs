    public interface IWindowFactory
    {
      CreateWindow Create();
    }
    
    public class WindowFactory : IWindowFactory
    {
      public CreateWindow Create() 
      {
        return new CreateWindow { Owner = Application.Current.MainWindow };
      }
    }
