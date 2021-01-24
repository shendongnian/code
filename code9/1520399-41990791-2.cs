    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return JsonResult(null, JsonRequestBehavior.AllowGet)
    
            // Uncomment each segment to test those feature.
    
            /* --- JsonValidationError Result ---
                {
                    "success": false,
                    "originalData": null,
                    "errorMessage": "Model state error test 1.\nModel state error test 2.",
                    "errorMessages": ["Model state error test 1.", "Model state error test 2."]
                }
                */
            ModelState.AddModelError("", "Model state error test 1.");
            ModelState.AddModelError("", "Model state error test 2.");
            return JsonValidationError();
    
            /* --- JsonError Result ---
                {
                    "success": false,
                    "originalData": null,
                    "errorMessage": "Json error Test.",
                    "errorMessages": ["Json error Test."]
                }
            */
            //return JsonError("Json error Test.");
    
            /* --- JsonSuccess Result ---
                {
                    "firstName": "John",
                    "lastName": "Doe"
                }
            */
            // return JsonSuccess(new { FirstName = "John", LastName = "Doe"});
        }
    }
