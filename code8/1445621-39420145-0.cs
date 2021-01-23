    public class ChampionController : Controller
    {
        [Route("Champion/ChampionById/{id}")]
        public ActionResult ChampionById(string id)
        {
           ChampionId ch = new ChampionId();
           ch.Id = id;
           return View(ch);
        }
    }
