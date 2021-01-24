    public static Task<HttpResponseMessage> Run(
        HttpRequestMessage req, ExecutionContext executionContext)
    {
        string invocationId = executionContext.InvocationId.ToString();
        var processor = new Processor(invocationId);
        return processor.Process(req);
    }
    public class Processor
    {
        private Logger logger;
        public Processor(string invocationId)
        {
            this.logger = new Logger(invocationId);
        }
        public async Task<HttpResponseMessage> Process(HttpRequestMessage req)
        {
            await this.logger.Log("Start");
            await this.DoStep1();
            await this.DoStep2();
            await this.logger.Log("Finish"); 
        }
        private async Task DoStep1()
        {
            await this.logger.Log("Step 1");
            // ...
        }
        private async Task DoStep2()
        {
            await this.logger.Log("Step 2");
            // ...
        }
    }
