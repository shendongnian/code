    using NUnit.Framework;
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    
    namespace AsyncProcessing {
    [TestFixture]
    public class PipelineTests {
        [Test]
        public async Task RunPipeline() {
            var pipeline = new MyPipeline();
            var data = Enumerable.Range(0, 1000).Select(x => new WorkItem(x, x));
            foreach(var item in data) {
                await pipeline.SendAsync(item);
            }
            pipeline.Complete();
            await pipeline.Completion;
            //all processing complete            
        }
    }
    class MyPipeline {
        private BufferBlock<WorkItem> inputBuffer;
        private TransformBlock<WorkItem, WorkItem> analyzeBlock;
        private TransformBlock<WorkItem, ResultArg> reportBlock;
        private ActionBlock<ResultArg> postOutput;
        public ConcurrentBag<ResultArg> OutputBuffer { get; }
        public Task Completion { get { return postOutput.Completion; } }
        public MyPipeline() {
            OutputBuffer = new ConcurrentBag<ResultArg>();
            CreatePipeline();
            LinkPipeline();
        }
        public void Complete() {
            inputBuffer.Complete();
        }
        public async Task SendAsync(WorkItem data) {
            await inputBuffer.SendAsync(data);
        }
        public void CreatePipeline() {
            var options = new ExecutionDataflowBlockOptions() {
                MaxDegreeOfParallelism = Environment.ProcessorCount,
                BoundedCapacity = 10
            };
            inputBuffer = new BufferBlock<WorkItem>(options);
            analyzeBlock = new TransformBlock<WorkItem, WorkItem>(item => {
                //Anylyze item....
                return item;
            }, options);
            reportBlock = new TransformBlock<WorkItem, ResultArg>(item => {
                //report your results, email.. db... etc.
                return new ResultArg(item.JobId, item.WorkValue);
            }, options);
            postOutput = new ActionBlock<ResultArg>(item => {
                OutputBuffer.Add(item);
            }, options);
        }
        public void LinkPipeline() {
            var options = new DataflowLinkOptions() {
                PropagateCompletion = true,
            };
            inputBuffer.LinkTo(analyzeBlock, options);
            analyzeBlock.LinkTo(reportBlock, options);
            reportBlock.LinkTo(postOutput, options);
        }
    }
    public class WorkItem {
        public int JobId { get; set; }
        public int WorkValue { get; set; }
        public WorkItem(int id, int workValue) {
            this.JobId = id;
            this.WorkValue = workValue;
        }
    }
    public class ResultArg {
        public int JobId { get; set; }
        public int Result { get; set; }
        public ResultArg(int id, int result) {
            this.JobId = id;
            this.Result = result;
        }
    }
}
