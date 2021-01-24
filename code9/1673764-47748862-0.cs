    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    namespace WpfApp2
    {
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
    
        }
    }
