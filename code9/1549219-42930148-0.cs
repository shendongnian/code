    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    
    namespace MyWorkProcessor {
    
        public class WorkProcessor {
    
            public WorkProcessor() {
                Processor = CreatePipeline();
            }    
    
            public async Task StartProcessing() {
                try {
                    await Task.Run(() => GetWorkFromDatabase());
                } catch (OperationCanceledException) {
                    //handle cancel
                }
            }
    
            private CancellationTokenSource cts {
                get;
                set;
            }
    
            private ITargetBlock<WorkItem> Processor {
                get;
            }
    
            private TimeSpan DatabasePollingFrequency {
                get;
            } = TimeSpan.FromSeconds(5);
    
            private ITargetBlock<WorkItem> CreatePipeline() {
                var options = new ExecutionDataflowBlockOptions() {
                    BoundedCapacity = 100,
                    CancellationToken = cts.Token
                };
                return new ActionBlock<WorkItem>(item => ProcessWork(item), options);
            }
    
            private async Task GetWorkFromDatabase() {
                while (!cts.IsCancellationRequested) {
                    var work = await GetWork();
                    await Processor.SendAsync(work);
                    await Task.Delay(DatabasePollingFrequency);
                }
            }
    
            private async Task<WorkItem> GetWork() {
                return await Context.GetWork();
            }
    
            private void ProcessWork(WorkItem item) {
                //do processing
            }
        }
    }
