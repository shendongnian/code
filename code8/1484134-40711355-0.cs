    public class UserController : BaseController {
        [Route("current")]
        public HttpResponseMessage GetCurrent(int version) {
            ValidateApiVersionAndState(version);
            var result = new List<object>() {
                new { Email = "Something@gmail.com", FirstName = "Some", LastName = "thing", DateOfBirth = new DateTime(1990, 9, 6), MontlySalary = "50000.00" },
                new { Email = "Steve@gmail.com", FirstName = "Steve", LastName = "Wonder", DateOfBirth = new DateTime(1984, 8, 4), MonthlySalary = 100000.00 }
            );
    
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
