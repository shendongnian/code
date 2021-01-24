    [RoutePrefix("api/tournament")]
    public class TournamentController : ApiController {
        //POST api/tournament/postmatchbet{? matching query strings}
        [HttpPost]
        [Route("PostMatchBet")]
        public HttpResponseMessage PostMatchBet(int tournamentId, int matchId, int teamId, string userEmail) { ... }
    }
