    [Export(typeof(IUserViewModel))]
    public class UserViewModel : PropertyChangedBase
    {
      private readonly IEventAggregator _events;
    
      [ImportingConstructor]
      public UserViewModel(IEventAggregator eventaggregator)
      {
         _events = eventaggregator;
      }
    }
    public interface IUserViewModel {
        void SomeMethod();
    }
