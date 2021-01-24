    public partial class MainWindow : Window, INotifyPropertyChanged //Notify the UI when changes occur
    {
        private string _location;
        private FileWatcher _fileWachter;
        public FileWatcher FileWatcher
        {
            get
            {
                return _fileWachter;
            }
            set
            {
                // this makes your FileWatcher observable by the ui
                _fileWachter = value;
                OnPropertyChanged();
            }
        }
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Location = string.Empty; //variavel que vai definir a localização da monitorização
            // DO NOT FORGET ABOUT THIS ONE
            // REGISTER FOR NotifyPropertyChanged
            DataContext = this;
        }
        private void btMon_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browseFolder = new FolderBrowserDialog();
            browseFolder.Description = "Selecione a pasta que deseja monitorizar. Todas as subpastas serão monitorizadas.";
            if (browseFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Location = browseFolder.SelectedPath;
                System.Windows.MessageBox.Show(Location);
            }
        } // Definição da localização que passa para o Filewatcher
        private void btInMon_Click(object sender, RoutedEventArgs e)
        {
            FileWatcher = new FileWatcher(Location);
        } 
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // it is good practice to check the handler for null before calling it
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
