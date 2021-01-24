    public class GooglePlayUIController : MonoBehaviour {
        // PRE: Leaderboard created in Google Play Developer
        // POST: Accesses the PlayGamesScript to display the Leaderboard UI
        public void ShowLeaderboards() {
		    PlayGamesScript.ShowLeaderboardsUI ();
	    }
        // PRE: Achievements created in Google Play Developer
        // POST: Accesses the PlayGamesScript to display the Achievement UI
	    public void ShowAchievements() {
		    PlayGamesScript.ShowAchievementsUI();
	    }
    }
