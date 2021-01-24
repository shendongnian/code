      public class PlanViewModel
      {
         public plan plan1 { get; set; }
      }
  
    public ActionResult Index(plan plan1)
    {
       var myCharge = new StripeChargeCreateOptions();
    
       string apiKey = "";
       var stripeClient = new StripeClient(apiKey);
       var planService = new StripePlanService(apiKey);
       StripePlan response = planService.Get("1234");
       plan1.Amount = (response.Amount).ToString();
    
       var viewModel = new PlanViewModel {
          plan1 = plan1
       };
    
       return View(viewModel);
    }
