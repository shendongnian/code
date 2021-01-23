    public class ChampionController : Controller
    {
        public ActionResult ChampionById(string id)
        {
            ChampionId ch = new ChampionId();
            if( !string.IsNullOrEmpty(id))
            { 
                ch.Id = id;
                return View(ch);
            }
            //<TODO> : handle when your id parameter is null
            return View(ch);
        }
