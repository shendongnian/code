    public class LanguageController : Controller
    	{
    		[HttpGet]
    		public JsonResult Translate(string word) 
    		{
    			var translatedWord = langRepo.Translate(word);
    			return Json(translatedWord, JsonRequestBehavior.AllowGet); 
    		}
    	}
