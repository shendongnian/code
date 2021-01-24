    using System.Threading.Tasks;
    using System.Windows;
    
    namespace Test
    {
    
        public partial class MainWindow : Window
        {
    
            int status = 0;
    
            // should be called when the window is loaded
            private void ApplicationStart()
            {
                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            }
    
            private void btnstart_Click(object sender, RoutedEventArgs e)
            {            
                worker.RunWorkerAsync();
                Console.WriteLine("Background worker started successfully");
                btnsave.IsEnabled = false;
            }
    
            private void worker_DoWork(object sender, DoWorkEventArgs e)
            {
    
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                   Console.WriteLine("Status : " + status);
                    if (status == 0)
                    {
                        status = 1;
                    }
            }
    
            private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
              Console.WriteLine("worker completed");
              btnsave.IsEnabled = true;
            }
        }
    }
