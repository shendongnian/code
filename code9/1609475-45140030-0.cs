    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace ThreadingSample.WPF
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private BackgroundWorker _worker;
            public MainWindow()
            {
                InitializeComponent();
                _worker = new BackgroundWorker();
                _worker.DoWork += WorkHeavy;
                _worker.ProgressChanged += ReportWork;
                _worker.RunWorkerCompleted += UpdateUI;
                _worker.WorkerReportsProgress = true;
            }
    
            private void ReportWork(object sender, ProgressChangedEventArgs e)
            {
                //get node object from e.UserState
                //update ui...
                //Console.WriteLine(String.Format("Currently bootstrapping {0} on {1}",
                //node.NodeName,
                //node.IPAddress));
            }
    
            private void UpdateUI(object sender, RunWorkerCompletedEventArgs e)
            {
               //update  ui...
            }
    
            private void WorkHeavy(object sender, DoWorkEventArgs e)
            {
                //heavy work....
                Parallel.ForEach(BootstrapNodes,
                new ParallelOptions { MaxDegreeOfParallelism = 2 },
                (node) =>
                {
                    _worker.ReportProgress(node);
                    ChefServer.BootstrapNode(node);
                });
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (_worker.IsBusy == false)
                {
                    _worker.RunWorkerAsync();
                }
            }
        }
    }
