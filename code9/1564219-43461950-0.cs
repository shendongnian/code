    [RoutePrefix("ComicBooks")]
    public class ComicBooksController : Controller {    
        [HttpGet]
        [Route("{PermaLinkName}")] //Matches GET ComicBooks/Spiderman
        public ActionResult ShowComicBook(string PermaLinkName){
            //...get comic book based on name
            return View(); //eventually include model with view
        }
    }
