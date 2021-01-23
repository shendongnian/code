    public class Controller {
        public async Task<int> PostToPipeline(int inputValue) {
            var message = new MessageIn(inputValue);
            MyPipeline.InputBuffer.Post(message);
            return await message.Completion.Task;
        }
    }
    public class MessageIn {
        public MessageIn(int value) {
            InputValue = value;
            Completion = new TaskCompletionSource<int>();
        }
        public int InputValue { get; set; }
        public TaskCompletionSource<int> Completion { get; set; }
    }
    public class MessageProcessed {
        public int ProcessedValue { get; set; }
        public TaskCompletionSource<int> Completion { get; set; }
    }
    public static class MyPipeline {
        public static BufferBlock<MessageIn> InputBuffer { get; private set; }
        private static TransformBlock<MessageIn, MessageProcessed> transform;
        private static ActionBlock<MessageProcessed> action;
        static MyPipeline() {
            BuildPipeline();
            LinkPipeline();
        }
        static void BuildPipeline() {
            InputBuffer = new BufferBlock<MessageIn>();
            transform = new TransformBlock<MessageIn, MessageProcessed>((Func<MessageIn, MessageProcessed>)TransformMessage, new ExecutionDataflowBlockOptions() {
                MaxDegreeOfParallelism = Environment.ProcessorCount,
                BoundedCapacity = 10
            });
            action = new ActionBlock<MessageProcessed>((Action<MessageProcessed>)CompletedProcessing, new ExecutionDataflowBlockOptions() {
                MaxDegreeOfParallelism = Environment.ProcessorCount,
                BoundedCapacity = 10
            });
        }
        static void LinkPipeline() {
            InputBuffer.LinkTo(transform, new DataflowLinkOptions() { PropagateCompletion = true });
            transform.LinkTo(action, new DataflowLinkOptions() { PropagateCompletion = true });
        }
        static MessageProcessed TransformMessage(MessageIn message) {
            return new MessageProcessed() {
                ProcessedValue = message.InputValue++,
                Completion = message.Completion
            };
        }
        static void CompletedProcessing(MessageProcessed message) {
            message.Completion.SetResult(message.ProcessedValue);
        }
    } 
