    public class PublisherController : Controller {
        private readonly IMapper mapper;
        public PublisherController(IJournalRepository journalRepository, IMembershipRepositry membershipRepository, IMapper mapper) {
            //...other code omitted for brevity
            this.mapper = mapper;
        }
        //...other code omitted for brevity
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(JournalViewModel journal) {
            var selectedJournal = mapper.Map<JournalViewModel, Journal>(journal);
    
            var opStatus = _journalRepository.DeleteJournal(selectedJournal);
            if (!opStatus.Status)
                throw new System.Web.Http.HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
    
            return RedirectToAction("Index");
        }
    }
