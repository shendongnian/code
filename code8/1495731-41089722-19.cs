    public class CustomerController : ApiController {
        private readonly IExcelService service;
    
        public CustomerController(IExcelService service) {
            this.service = service;
        }
        [HttpGet]
        public IHttpActionResult GetCustomer() {
            IEnumerable<CustomerViewModel> customer = service.GetSpreadsheet();
            return Ok(customer);
        }    
    }
