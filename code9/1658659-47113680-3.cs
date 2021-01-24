    [EnableCors("MyPolicy")]
    Route("api/[controller]")]
    public class MyController : Controller
    {
        private readonly IMyService _myService;
        private  IHubContext<RulesHub> _rulesHubContext;    
    
        public MyController(IMyService myService, IRuleService ruleService, IHubContext<RulesHub > rulesHubContext)
        {
            _myService = myService;
            _rulesHubContext = rulesHubContext;
        }
    
        [HttpPost]
        public void Post([FromBody]MyClass myClass)
        {
            _myService.Add(myClass);
            // Load your rules from somewhere 
            _rulesHubContext.Clients.All.InvokeAsync("SendRules", rules);
        }
    }
