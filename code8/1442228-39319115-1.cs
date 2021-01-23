    public partial class MainWindow: Window,INotifyPropertyChanged
        {
            
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
            }
            public double Progressvalue
            {
                get
                {
                    return _Progressvalue;
    
                } 
                set
                {
                    if(value!=_Progressvalue)
                    {
                        _Progressvalue=value;
                        OnPropertyChanged();
                    }
                }
             }
            private Double _Progressvalue=0;
            private bool _IsEnabled=true;
           
            public Boolean IsButtonEnabled { 
                get
                {
                    return _IsEnabled;
                 }
                
                set
                {
                    if(value!=_IsEnabled)
                    {
                        _IsEnabled = value;
                        OnPropertyChanged();
                    }
                }
            }
            private async  void Button_Click(object sender, RoutedEventArgs e)
            {
                IsButtonEnabled = false;
                await AsyncTransferFiles();
                IsButtonEnabled = true;
                scrv_Log.ScrollToBottom();
                
            }
            
            private String fileCounter;
             public String FileCounter
            {
                get
                { return fileCounter; }
                set
                {
                    if (value != fileCounter)
                    {
                        fileCounter = value;
                        OnPropertyChanged();
                    }
                }
            }
      
           
            
    
    
        
    
            private ObservableCollection<String> _Datas = new ObservableCollection<string>();
            public ObservableCollection<String> Datas
            {
                get
                {
                    return _Datas;
                }
            }
             private async Task AsyncTransferFiles()
            {
                
                var fileNames = Directory.GetFiles("C:\\Data1").ToList();
                int totalCount = fileNames.Count;
                pr = (double)1 / totalCount;
                int counter = 0;
                var progress = new Progress<double>();
                progress.ProgressChanged += (sender, e) =>
                    {
    
                       Progressvalue = Double.Parse(e.ToString());
                        
                    };
                foreach (var fileName in fileNames)
                {
                    await (CopyFileAsync(fileName, "C:\\GradebookTemp1\\" + fileName.Split('\\')[2], progress, ++counter));
                }
            }
    
    
         
             double pr = 0.0;
             public async Task CopyFileAsync(string sourcePath, string destinationPath,IProgress<double> progress ,int fileCounter)
             {
                 using (Stream source = File.Open(sourcePath,FileMode.Open))
                 {
                     using (Stream destination = File.Create(destinationPath))
                     {
                         await source.CopyToAsync(destination);
                         progress.Report((int)(pr*fileCounter*100));
                         FileCounter = fileCounter.ToString();
                         Datas.Add("Copied File: " + sourcePath);
                         scrv_Log.ScrollToBottom();
                         
                     }
                 }
                 
             }
    
            private void EnableButton()
            {
                IsButtonEnabled = true;
            }
    
            private void OnPropertyChanged([CallerMemberName] String propertyName=null)
            {
                var handler = PropertyChanged;
                if(null!=handler)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
    
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
