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
        private IObservable<Message> output;
        private TaskCompletionSource<bool> areWeDoneYet;
        public IList<Message> OutputMessages { get; set; }
        public MyDataflow() {
            OutputMessages = new List<Message>();
            CreatePipeline();
            LinkPipeline();
        }
        public void CreatePipeline() {
            var options = new ExecutionDataflowBlockOptions() {
                BoundedCapacity = 13,
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
            output = xForm1.AsObservable<Message>();
            areWeDoneYet = new TaskCompletionSource<bool>();
        }
        public void LinkPipeline() {
            var options = new DataflowLinkOptions() {
                PropagateCompletion = true
            };
            
            buffer.LinkTo(xForm1, options);
            
            var subscription = output.Subscribe(msg => {
                Task.Delay(rnd.Next(1000, 3000)).Wait();
                OutputMessages.Add(msg);
            }, () => areWeDoneYet.SetResult(true));            
        }
        public Task<bool> PostData(IEnumerable<Message> data) {            
            foreach (var item in data) {
                buffer.Post(item);
            }
            buffer.Complete();
            return areWeDoneYet.Task;
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
