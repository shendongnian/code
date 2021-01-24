    public class ParametryWyjscioweViewModel : INotifyPropertyChanged
    {
        public List<ParametrWyjsciowy> ListaParametryWyjsciowe { get; set; }
        private static ParametryWyjscioweViewModel _instance = new ParametryWyjscioweViewModel();
        public static ParametryWyjscioweViewModel Instance { get { return _instance; } }
        BackgroundWorker _worker;
        public int _progress = 20;
        public int Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Progress"));
            }
        }
        public void startBackgroundProcess()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            _worker.ProgressChanged += worker_Progress_Changed;
            _worker.RunWorkerAsync();
        }
        private ParametryWyjscioweViewModel()
        {
            ListaParametryWyjsciowe = new List<ParametrWyjsciowy>();
        }
        private void worker_Progress_Changed(object sender, ProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage;
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            XmlReader xmlReader = new XmlReader(System.Environment.CurrentDirectory + @"\SqlConfig.xml");
            string sql = xmlReader.GetElementValue(0, "ParametryWyjsciowe");
            DataTable dt = DataBaseManager.ExecuteQueryResult(sql);
            List<ParametrWyjsciowy> temp = new List<ParametrWyjsciowy>();
            foreach (DataRow dr in dt.Rows)
            {
                ParametrWyjsciowy parametr = new ParametrWyjsciowy();
                parametr.IdKartoteka = int.Parse(dr["id_kartoteka"].ToString());
                parametr.NazwaSkr = dr["nazwaskr"].ToString();
                parametr.NazwaDl = dr["nazwadl"].ToString();
            }
            Application.Current.Dispatcher.BeginInvoke(new Action(()=> 
            {
                ListaParametryWyjsciowe = temp;
                OnPropertyChanged("ListaParametryWyjsciowe");
            }));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
