    //Controller.cs
    [Route("api/eci/test/[action]")]
    public class Controller {
        private readonly ILogic service;
        public Controller(ILogic service) {
            this.service = service;
        }
        [HttpPost({"id"})]
        public void ingestedDocs(string id) {
            service.ingest(id);
        }
    }
