    public class CustomersController : ApiController {
        private IAPICustomerRepository repository;
        public CustomersController(IAPICustomerRepository repository) {
            this.repository = repository;
        }
        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null) {
            var customerDtos = repository.GetCustomers(query);
            return Ok(customerDtos);
        }
        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id) {
            var customer = repository.GetCustomer(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer([FromBody]CustomerDto customerDto) {
            if (!ModelState.IsValid)
                return BadRequest();
            var id = repository.CreateCustomer(customerDto);
            customerDto.Id = id;
            return Created(new Uri(Request.RequestUri + "/" + id), customerDto);
        }
        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, [FromBody]CustomerDto customerDto) {
            if (!ModelState.IsValid)
                return BadRequest();
            var updated = repository.UpdateCustomer(id, customerDto);
            if (updated == null)
                return NotFound();
            return Ok();
        }
        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) {
            var deleted = repository.DeleteCustomer(id);
            if (deleted == null)
                return NotFound();
            return Ok();
        }
    }
