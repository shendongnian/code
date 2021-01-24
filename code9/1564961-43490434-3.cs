    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    
    namespace Wpf.Test01
    {
        /// <summary>
        /// Interaction logic for Stack_43489182.xaml
        /// </summary>
        public partial class Stack_43489182 : Window
        {
            private BackgroundWorker worker;
            public Stack_43489182()
            {
                InitializeComponent();
    
                this.worker = new BackgroundWorker();
                this.worker.DoWork += Worker_DoWork;
                this.worker.ProgressChanged += Worker_ProgressChanged;
                this.worker.WorkerReportsProgress = true;
            }
    
            private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                this.progressBar.Value = e.ProgressPercentage;
            }
    
            private void Worker_DoWork(object sender, DoWorkEventArgs e)
            {
                /** you need to put code from Util.cs here **/
                int i = 1;
                while(i <= 10)
                {
                    this.worker.ReportProgress((int)((i / (double)10) * 100));
    
                    Thread.Sleep(1000);
                    i++;
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                progressBar.Value = 0;
                this.worker.RunWorkerAsync();
            }
        }
    }
