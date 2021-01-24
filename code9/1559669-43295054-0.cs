    using System.Collections.ObjectModel;
    using GalaSoft.MvvmLight;
    
    namespace WpfApp4.ViewModel
    {
        public class MainViewModel : ViewModelBase
        {
            public MainViewModel()
            {
                BarCollection = new ObservableCollection<BarModel>
                {
                    new BarModel { Id = 1, Name = "Bar 1", },
                    new BarModel { Id = 2, Name = "Bar 2", },
                    new BarModel { Id = 3, Name = "Bar 3", },
                };
    
                FooCollection = new ObservableCollection<FooViewModel>
                {
                    new FooViewModel{ Id = 1, },
                    new FooViewModel{ Id = 2, },
                    new FooViewModel{ Id = 3, },
                };
    
            }
    
    
            public ObservableCollection<BarModel> BarCollection { get; set; }
            public ObservableCollection<FooViewModel> FooCollection { get; set; }
        }
    
        public class FooViewModel : ViewModelBase
        {
            private BarModel _bar;
    
            public int Id { get; set; }
            public BarModel Bar { get => _bar; set => Set( ref _bar, value ); }
        }
    
        public class BarModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public override string ToString()
            {
                return Name;
            }
        }
    }
