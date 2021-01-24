    public class EcoleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void FirePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _nomEcole;
        public string NomEcole
        {
            get { return MainWindow._RE.EcoleVisualisee.Nom; }
            set
            {
                if (MainWindow._RE.EcoleVisualisee.Nom != value)
                {
                    MainWindow._RE.EcoleVisualisee.Nom = value;
                    this.FirePropertyChanged("NomEcole");
                }
            }
        }
    }
