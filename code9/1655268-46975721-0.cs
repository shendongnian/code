        private readonly IMyService _myService;
        //You can use Dependency Injection if you want to. 
        public Functions(IMyService myService)
        {
            _myService = myService;
        }
        public void ProcessQueue1([QueueTrigger("queue1")] string item)
        {
            //You can get the message as a string or it can be strongly typed
            _myService.ProcessQueueItem1(item);
        }
        public void ProcessQueue2([QueueTrigger("queue2")] MyObject item)
        {
            //You can get the message as a string or it can be strongly typed
            _myService.ProcessQueueItem2(item);
        }
