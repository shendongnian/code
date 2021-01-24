    UI -> ViewModel -> Model <- DAL
    namespace MyApp.Model
    {
        public interface IMyRepo
        {
             IEnumerable<Model.CountryList> GetAllCountries();
        }
    }
    namespace MyApp.DAL
    {
        public class MyRepo : IMyRepo
        {
             IEnumerable<Model.CountryList> GetAllCountries()
             {
                 /**
                 data access
                 **/
             }
        }
    }
    namespace MyApp.ViewModel
    {
        public class MainViewModel : ViewModelBase
        {
             public MainViewModel(IMyRepo repo)
             {
                  this.Repo = repo;
             }
        }
    }
