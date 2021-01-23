    [TestFixture]
    public class TestRunner {
        [Test]
        public void TestPipeline() {
            var data = Enumerable.Range(0, 30).Select(x => new Message(x, x)).ToList();
            var target = new MyDataflow();
            target.PostData(data).Wait();
            Assert.IsTrue(data.SequenceEqual(target.OutputMessages));
        }
    }
    public class MyDataflow {
        private static Random rnd = new Random();
        private BufferBlock<Message> buffer;
        private TransformBlock<Message, Message> xForm1;
        private ActionBlock<Message> action;
        public IList<Message> OutputMessages { get; set; }
        public MyDataflow() {
            OutputMessages = new List<Message>();
            CreatePipeline();
            LinkPipeline();
        }
        public void CreatePipeline() {
            var options = new ExecutionDataflowBlockOptions() {
                BoundedCapacity = 2,
                MaxDegreeOfParallelism = 10,
                EnsureOrdered = true
            };
            buffer = new BufferBlock<Message>();
            xForm1 = new TransformBlock<Message, Message>(x => {
                Console.WriteLine($"{DateTime.Now.TimeOfDay} - Started Id: {x.Id}");
                Task.Delay(rnd.Next(1000, 3000)).Wait();
                Console.WriteLine($"{DateTime.Now.TimeOfDay} - Finished Id: {x.Id}");
                return x;
            }, options);
            action = new ActionBlock<Message>(x => {
                Console.WriteLine($"{DateTime.Now.TimeOfDay} - Output  Id: {x.Id} Value: {x.Value}");
                //this delay will cause the messages to be unordered
                Task.Delay(rnd.Next(1000, 3000)).Wait();
                OutputMessages.Add(x);
            }, options);
        }
        public void LinkPipeline() {
            var options = new DataflowLinkOptions() {
                PropagateCompletion = true
            };
            
            buffer.LinkTo(xForm1, options);
            xForm1.LinkTo(action, options);
        }
        public Task PostData(IEnumerable<Message> data) {
            
            foreach (var item in data) {
                buffer.Post(item);
            }
            buffer.Complete();
            return action.Completion;
        }
    }
    public class Message {
        public Message(int id, int value) {
            this.Id = id;
            this.Value = value;
        }
        public int Id { get; set; }
        public int Value { get; set; }
    }
