    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }
    }
    public class Contexte : BaseViewModel
    {
        private Affaire _selectedAffaire;
        private Phase _selectedPhase;
        public ObservableCollection<Affaire> ListeDesAffaires { get; set; }
        public Affaire SelectedAffaire
        {
            get { return _selectedAffaire; }
            set
            {
                _selectedAffaire = value;
                this.NotifyPropertyChanged("SelectedAffaire");
            }
        }
        public Phase SelectedPhase
        {
            get { return _selectedPhase; }
            set
            {
                _selectedPhase = value;
                this.NotifyPropertyChanged("SelectedPhase");
            }
        }
        public Contexte()
        {
            ListeDesAffaires = new ObservableCollection<Affaire>
            {
                new Affaire("Affaire1"),
                new Affaire("Affaire2")
            };
        }
    }
    public class Affaire : BaseViewModel
    {
        private string nom;
        public string Nom
        {
            get { return this.nom; }
            set
            {
                this.nom = value;
                this.NotifyPropertyChanged("Nom");
            }
        }
        
        public ObservableCollection<Phase> ListPhases { get; set; }
        public Affaire(string n)
        {
            nom = n;
            ListPhases = new ObservableCollection<Phase>
            {
                new Phase { NomPhase = nom + "_Phase1" },
                new Phase { NomPhase = nom + "_Phase2" }
            };
        }
    }
    public class Phase : BaseViewModel
    {
        private string nomPhase;
        public string NomPhase
        {
            get { return this.nomPhase; }
            set
            {
                this.nomPhase = value;
                this.NotifyPropertyChanged("NomPhase");
            }
        }
        public ObservableCollection<Assemblage> ListAssemblages { get; set; }
    }
    public class Assemblage : BaseViewModel
    {
        private string nom;
        public string Nom
        {
            get { return this.nom; }
            set
            {
                this.nom = value;
                this.NotifyPropertyChanged("Nom");
            }
        }
    }
