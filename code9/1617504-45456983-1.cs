    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
        public partial class frmDoWork : Form
        {
            CancellationTokenSource cts = null;
            Task backgroundTask = null;
    
            public frmDoWork()
            {
                InitializeComponent();
            }
    
            private void WorkToDoInBackgroundThread(IProgress<int> progress, CancellationToken cancellationToken)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        Task.Delay(1000).Wait(cancellationToken);
                        progress.Report(i);
                        System.Diagnostics.Debug.WriteLine($"{i} - {DateTime.Now}");
                    }
                }
                catch(OperationCanceledException ex)
                {
    
                }
                
            }
    
            private void cmdDoWork_Click(object sender, EventArgs e)
            {
                cts = new CancellationTokenSource();
                Progress <int> prg= new Progress<int>(x => this.Text = $"Iteration - {x}");
    
                backgroundTask = Task.Run(()=> WorkToDoInBackgroundThread(prg, cts.Token));
            }
    
            private void cmdAbort_Click(object sender, EventArgs e)
            {
                cts?.Cancel();
            }
        }
    }
