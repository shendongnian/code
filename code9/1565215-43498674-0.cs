    public class ExampleController : Controller
    {
         private readonly IEnumerable<IActionDialogType> actionDialogType;
         public ExampleController(IActionDialogType actionDialogType)
         {
             this.actionDialogType = actionDialogType;
         }
    
         public IActionResult Get()
         {
             foreach(IActionDialogType instance in actionDialogType)
             {
                  // Should expose via each now.
                  var name = instance.GetType().Name;
             }
         }
    }
