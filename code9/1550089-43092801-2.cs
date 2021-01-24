    public class LinkBookingController : ApiController {
        private IBookingService bookingService;
    
        public LinkBookingController(IBookingService service) {
            bookingService = service;
        }
    
        [HttpPost]
        [Route("TnC")]
        public IHttpActionResult TnC(CustomViewModel myViewModel) {
        
            return Json(bookingService.TnC(myViewModel, User));
        
        }
    }
