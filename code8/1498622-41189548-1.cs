    class SomeController : Controller{
    
       private SpecialFormatter _formatter;
       public SomeController(SpecialFormatter formatter)
          _formatter = formatter;
       }
       public ActionResult SomeAction(string input){
          string output = _formatter.DoSpecialFormatting(input);
          // stuff
       }
    }
