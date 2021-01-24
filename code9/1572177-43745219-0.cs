    [Route("Bank")]
    public class BankController : Controller
    {
        private IBankService BankService;
        
        public BankController(IBankService bankService) {
            BankService = bankService ?? new IBankService();
        }
        
        [HttpGet("{bankStringId}")]
        public string Index(string bankStringId)
        {
            var result = someServiceMethod(bankStringId);
            return result;
        }
    }
