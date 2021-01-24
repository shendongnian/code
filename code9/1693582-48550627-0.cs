    [RoutePrefix("api/apolice")]
    public class ApoliceController : ApiController
    {
        private GV db = new GV();
    
        [HttpGet]
    	[Route("status")] //route will be api/apolice/status
        public void ListStatus()
        {
            Ok(db.EthereumStatus.ToList());
        }
    
        [HttpGet]
    	[Route("")] //route will be api/apolice
        public void ListApolices()
        {
            Ok(db.ApoliceEthereum.ToList());
        }
    }
