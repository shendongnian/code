    using System;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1 {
        public partial class Form1 : Form {
    
            private CancellationTokenSource cancellationTokenSource;
            private TransformBlock<WorkItem, WorkItem> startWork;
            private ActionBlock<WorkItem> completeWork;
            private IProgress<int> progressBar1Value;
            private IProgress<int> progressBar2Value;
    
            public Form1() {
                InitializeComponent();
                btnCancel.Enabled = false;
            }
    
            private async void btnAdd_Click(object sender, EventArgs e) {
                if(!btnCancel.Enabled) {
                    CreatePipeline();
                    btnCancel.Enabled = true;
                }
                var data = Enumerable.Range(0, 20).Select(_ => new WorkItem());
                foreach(var workItem in data) {
                    await startWork.SendAsync(workItem);
                    progressBar1.Value++;                
                }
            }
    
            private async void btnCancel_Click(object sender, EventArgs e) {
                btnAdd.Enabled = false;
                btnCancel.Enabled = false;
    
                cancellationTokenSource.Cancel();
    
                await completeWork.Completion.ContinueWith(tsk => this.Invoke(new Action(() => this.Text = "Flow Cancelled")), 
                                                           TaskContinuationOptions.OnlyOnCanceled);
    
                progressBar4.Value += progressBar1.Value;
                progressBar4.Value += progressBar2.Value;
    
                // Reset the progress bars that track the number of active work items.
                progressBar1.Value = 0;
                progressBar2.Value = 0;
    
                // Enable the Add Work Items button.      
                btnAdd.Enabled = true;
            }
    
            private void CreatePipeline() {
                cancellationTokenSource = new CancellationTokenSource();
                progressBar1Value = new Progress<int>(_ => progressBar1.Value++);
                progressBar2Value = new Progress<int>(_ => progressBar2.Value++);
    
                startWork = new TransformBlock<WorkItem, WorkItem>(async workItem => {
                    await workItem.DoWork(250, cancellationTokenSource.Token);
                    progressBar1Value.Report(0); //Value is ignored since the progressbar value is simply incremented
                    progressBar2Value.Report(0); //Value is ignored since the progressbar value is simply incremented
                    return workItem;
                },
                new ExecutionDataflowBlockOptions {
                    CancellationToken = cancellationTokenSource.Token
                });
    
                completeWork = new ActionBlock<WorkItem>(async workItem => {
                    await workItem.DoWork(1000, cancellationTokenSource.Token);
                    progressBar1Value.Report(0); //Value is ignored since the progressbar value is simply incremented
                    progressBar2Value.Report(0); //Value is ignored since the progressbar value is simply incremented
                },
                new ExecutionDataflowBlockOptions {
                    CancellationToken = cancellationTokenSource.Token,
                    MaxDegreeOfParallelism = 2
                });
    
                startWork.LinkTo(completeWork, new DataflowLinkOptions() { PropagateCompletion = true });
            }
        }
    
        public class WorkItem {
            public async Task DoWork(int milliseconds, CancellationToken cancellationToken) {
                if(cancellationToken.IsCancellationRequested == false) {
                    await Task.Delay(milliseconds);
                }
            }
        }
    }
