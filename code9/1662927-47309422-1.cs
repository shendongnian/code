     public partial class ProcessFiles : Window, INotifyPropertyChanged
    {
        public void SetPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<FileInfo> myFileList = new ObservableCollection<FileInfo>();
        
        public ObservableCollection<FileInfo> MyFileList
        {
             get{return myFileList;}
             set
                {
                   myFileList = value;
                   SetPropertyChanged("MyFileList");
                }
        }
        public ProcessFiles()
        {
            InitializeComponent();
            dGrid.AutoGenerateColumns = true;
            dGrid.UpdateLayout();
        }
        private void pButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Task.Factory.StartNew(() => ListMyFiles(myFileList));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " +ex.Message);
            }
            finally
            {
                MessageBox.Show("Done.");
            }
            dGrid.ItemsSource = MyFileList;
        }
        private void ListMyFiles(ObservableCollection<FileInfo> mylist)
        {
            //throw new NotImplementedException();
            foreach (FileInfo f in new DirectoryInfo(@"D:\Dummy2").GetFiles("*.*", SearchOption.TopDirectoryOnly))
            {
                // var currentFile = f;
                System.Threading.Thread.Sleep(10);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.ReadyItem.Content = "Updating..." + f.FullName;
                    mylist.Add(f);
                }), DispatcherPriority.Background);
            }
        }
