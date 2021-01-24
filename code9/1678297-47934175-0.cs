    public class DashboardViewModel
    {
        public MatchupList Matchups {get;set;
        public PlayerList Players {get;set;}
    }
    public ActionResult FtblDashboard()
    {
        var matchups = db.usp_GetMatchups();
        var players = db.usp_GetAllPlayers()
        var viewModel = new DashboardViewModel
            { Matchups = matchups, Players = players };        
        return View(viewModel);
    }
