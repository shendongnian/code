    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfApp2
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void FillClick(object sender, RoutedEventArgs e)
            {
                Phase ph = new Phase();
                ph.NomPhase = "SomeId";
                ph.ListAssemblages = new ObservableCollection<Assemblage>()
                {
                    new Assemblage { Nom =  "Assemblage1" },
                    new Assemblage { Nom =  "Assemblage2" }
                };
                Contexte.SelectedPhase = ph;
            }
        }
    }
