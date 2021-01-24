    [EnableCors("MyPolicy")]
    Route("api/[controller]")]
    public class MyController : Controller
    {
        private readonly IMyService _myService;
        private RulesHub _rulesHub;    
    
        public MyController(IMyService myService, IRuleService ruleService, IHubContext<RulesHub > rulesHubContext)
        {
            _myService = myService;
            _rulesHub = rulesHubContext;
        }
    
        [HttpPost]
        public void Post([FromBody]MyClass myClass)
        {
            _myService.Add(myClass);
            // Load your rules from somewhere 
            rulesHubContext.All.InvokeAsync("SendRules", rules);
        }
    }
