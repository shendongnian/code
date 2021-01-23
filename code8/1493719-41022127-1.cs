    public class MessageController : ApiController
    {
        [HttpGet]
        [Route("api/Message/PaginateMessages/{conversationId}/{lastMessageId}")]
        public async Task<List<MessageDTO>> PaginateMessages(
             int conversationId, int lastMessageId)
        {
            return null;
        }
    }
