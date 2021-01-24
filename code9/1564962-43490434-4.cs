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
    using System.Windows.Threading;
    
    namespace Wpf.Test01
    {
        /// <summary>
        /// Interaction logic for Stack_43489182.xaml
        /// </summary>
        public partial class Stack_43489182 : Window
        {
            private BackgroundWorker worker;
            private Utils util;
    
            public Stack_43489182()
            {
                InitializeComponent();
    
                this.worker = new BackgroundWorker();
                this.worker.DoWork += Worker_DoWork;
                //this.worker.ProgressChanged += Worker_ProgressChanged;
                this.worker.WorkerReportsProgress = true;
    
                this.util = new Utils();
                util.FreeSpace_ProgressChanged += Worker_ProgressChanged;
            }
    
            private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                                                           new Action(() => this.progressBar.Value = e.ProgressPercentage));
            }
    
            private void Worker_DoWork(object sender, DoWorkEventArgs e)
            {
                var utils = e.Argument as Utils;
    
                if(utils != null)
                {
                    utils.copy();
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                progressBar.Value = 0;
                this.worker.RunWorkerAsync(util);
            }
    
            public class Utils
            {
                public event ProgressChangedEventHandler FreeSpace_ProgressChanged;
    
                private void freeSpace()
                {
                    int i = 1;
                    while (!isFinished(i))
                    {
                        
                        if(FreeSpace_ProgressChanged != null)
                        {
                            FreeSpace_ProgressChanged(i, new ProgressChangedEventArgs((int)((i / 10.0) * 100), null));
                        }
    
                        Thread.Sleep(1000);
    
                        i++;
                    }
                }
    
                private bool isFinished(int i)
                {
                    // Return true if the copy is finish
                    // Return false if the copy is not finish
                    return i == 10 ? true : false;
                }
    
                public void copy()
                {
                    //Copy a file 
                    freeSpace();
                }
            }
        }
    }
