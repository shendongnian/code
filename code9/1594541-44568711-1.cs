        [Route("api/[controller]")]
        public class CustomersController : Controller
        {
            ILogger<CustomersController> log;
            ICustomerRepository customerRepository;
    
            public CustomersController(ILogger<CustomersController> log, ICustomerRepository customerRepository)
            {
                this.log = log;
                this.customerRepository = customerRepository;
            }
    
            /// <summary>
            /// Get a specific customer 
            /// </summary>
            /// <param name="customerId">The id of the Customer to get</param>
            /// <returns>A customer  with id matching the customerId param</returns>
            /// <response code="200">Returns the customer </response>
            /// <response code="404">If a customer  could not be found that matches the provided id</response>
            [HttpGet("{customerId:int}")]
            [ProducesResponseType(typeof(ApiResult<Customer>), 200)]
            [ProducesResponseType(typeof(ApiResult), 404)]
            public async Task<IActionResult> GetCustomer([FromRoute] int customerId)
            {
                try
                {
                    return Ok(new ApiResult<Customer>(await customerRepository.GetCustomerAsync(customerId)));
                }
                catch (ResourceNotFoundException)
                {
                    return NotFound(new ApiResult($"No record found matching id {customerId}"));
                }
            }
        }
