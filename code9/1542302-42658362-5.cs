    public class HomeController {
        
        public ActionResult Index() {
            
            return this.View( new HomeViewModel() );
        }
        
        [HttpPost]
        public ActionResult Index(HomeViewModel model) {
            
            if( model == null ) return this.NotFound();
            
            if( model.FirstValue == model.SecondValue ) {
                model.Message = "Values match";
            }
            else {
                model.Message = "Values are different";
            }
            
            return this.View( model );
        }
    }
