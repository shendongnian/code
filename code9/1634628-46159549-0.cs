    public class PriorityMessageQueue {        
        private TransformBlock<MyMessage, MyMessage> _messageReciever;
        public PriorityMessageQueue() {
            var executionDataflowBlockOptions = new ExecutionDataflowBlockOptions {
                MaxDegreeOfParallelism = Environment.ProcessorCount,
                BoundedCapacity = 50
            };
            var prioritizeMessageBlock = new ActionBlock<MyMessage>(msg => {
                SetMessagePriority(msg);
            }, executionDataflowBlockOptions);
            _messageReciever = new TransformBlock<MyMessage, MyMessage>(msg => NewMessageRecieved(msg), executionDataflowBlockOptions);
            _messageReciever.LinkTo(prioritizeMessageBlock, new DataflowLinkOptions { PropagateCompletion = true });
        }
        public async Task<bool> EnqueueAsync(MyMessage message) {
            return await _messageReciever.SendAsync(message);
        }
        private MyMessage NewMessageRecieved(MyMessage message) {
            //do something when a new message arrives
            //pass the message along in the pipeline
            return message;
        }
        private void SetMessagePriority(MyMessage message) {
            //Handle a message
        }
    }
