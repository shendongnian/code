    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using WpfApp1.Annotations;
    
    namespace WpfApp1
    {
        public partial class MainWindow : INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
    
            public ObservableCollection<Contact_Info> Contacts { get; } =
                new ObservableCollection<Contact_Info>
                {
                    new Contact_Info
                    {
                        CompanyName = "Apple",
                        OppDataList = {new SharpspringOpportunityDataModel {ProjectName = "World take over"}}
                    },
                    new Contact_Info
                    {
                        CompanyName = "Google",
                        OppDataList = {new SharpspringOpportunityDataModel {ProjectName = "World take over"}}
                    },
                    new Contact_Info
                    {
                        CompanyName = "Microsoft",
                        OppDataList = {new SharpspringOpportunityDataModel {ProjectName = "World take over"}}
                    }
                };
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class Contact_Info
        {
            public string CompanyName { get; set; }
    
            public ObservableCollection<SharpspringOpportunityDataModel> OppDataList { get; } =
                new ObservableCollection<SharpspringOpportunityDataModel>();
        }
    
        public class SharpspringOpportunityDataModel
        {
            public string ProjectName { get; set; }
        }
    }
