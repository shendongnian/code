    public class CommentController : Controller
    {
        private readonly IRequest<PublishComment> handler;
        public CommentController(IRequest<PublishComment> handler)
        {
            this.handler = handler;
        }
        public ActionResult Publish(string comment) =>
            this.handler.Handle(new PublishComment { Comment = comment });
    }
