    :
    
     public partial class MainWindow : Window
        {
            public Contact contact;
            public MainWindow()
            {
                InitializeComponent();
                contact = new Contact();
                this.DataContext = contact;
    
                contact.Titles.Add(new Title { title = "Mr" });
                contact.Titles.Add(new Title { title = "Dr " });
                contact.Titles.Add(new Title { title = "Mis" });
                contact.Titles.Add(new Title { title = "Miss" });
                contact.Titles.Add(new Title { title = "Sir" });
    
                contact.Genders.Add(new Gender { gender = "Male" });
                contact.Genders.Add(new Gender { gender = "Female" });
            }
        }
    
        public class Contact : INotifyPropertyChanged
        {
            public ObservableCollection<Title> Titles
            {
                get { return _titles; }
                set
                {
                    _titles = value;
                    NotifyPropertyChanged(nameof(Titles));
                }
            }
    
            public ObservableCollection<Gender> Genders
            {
                get { return _genders; }
                set
                {
                    _genders = value;
                    NotifyPropertyChanged(nameof(Genders));
                }
            }
    
            private ObservableCollection<Title> _titles { get; set; }
            private ObservableCollection<Gender> _genders { get; set; }
    
    
            public Contact()
            {
                Titles = new ObservableCollection<Title>();
                Genders = new ObservableCollection<Gender>();
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
        }
    
        public class Title
        {
            public string title { get; set; }
            public override string ToString()
            {
                return title;
            }
        }
    
        public class Gender
        {
            public string gender { get; set; }
            public override string ToString()
            {
                return gender;
            }
        }
