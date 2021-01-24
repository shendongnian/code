    public class MyController : ApiController {
        IInternshipsViewModelFactory factory;
        IInternshipRepository _internshipRepository;
        public MyController(IInternshipsViewModelFactory factory, IInternshipRepository repository) {
            this.factory = factory;
            this._internshipRepository = repository;
        }
        public IHttpActionResult GetInternshipsForCoordinator() {
            var models = factory.CreateInternshipsViewModel(_internshipRepository, _internshipRepository.GetAll());
            return Ok(models);
        }
    }
