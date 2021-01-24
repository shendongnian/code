    [RoutePrefix("api/tournament")]
    public class TournamentController : ApiController {
        //POST api/tournament/postmatchbet?[any matching query string]
        [HttpPost]
        [Route("PostMatchBet")]
        public HttpResponseMessage PostMatchBet(int tournamentId, int matchId, int teamId, string userEmail) { ... }
    }
