    public class FooController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> DoStuffWithTask() => await MyOk(async () => await FooWithTask());
        //[HttpGet]
        public async Task<IHttpActionResult> DoStuffWithVoid() => await MyOk(() => FooWithVoid());
        public async Task<IHttpActionResult> DoAsync()
        {
            return await MyOk(FooWithTask());
        }
        private async Task<IHttpActionResult> MyOk(Task task)
        {
            await task;
            return Ok();
        }
        private async Task<IHttpActionResult> MyOk(Action stuff)
        {
            stuff();
            return Ok();
        }
        public void FooWithVoid()
        {
            // Do Stuff!
        }
        public async Task FooWithTask()
        {
            // Do Stuff!
            return;
        }
    }
