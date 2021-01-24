    using GooglePlayGames;
    using GooglePlayGames.BasicApi;
    using UnityEngine;
    public class PlayGamesScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.Activate();
		SignIn ();
	}
    // PRE: None
    // POST: Logs player into Google Play Games
 	void SignIn()
	{
		Social.localUser.Authenticate (success => {});
	}
	#region Achievements
    // PRE: Achievement created in Google Play Developer and the 
    // achievement has been achieved by the player
    // POST: Unlocks the achievement for the player
	public static void UnlockAchievement(string id)
	{
		Social.ReportProgress(id, 100, success => { });
	}
    // PRE: Achievement created in Google Play Developer and set to Incremental
    // achievement
    // POST: Increments the achievement by selected steps established by 
    // the stepsToIncrement variable
	public static void IncrementAchievement(string id, int stepsToIncrement)
	{
		PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
	}
    // PRE: Achievements created in Google Play Developer and player 
    // is logged in
    // POST: Shows the Achievements UI
	public static void ShowAchievementsUI()
	{
		if(PlayGamesPlatform.Instance.IsAuthenticated())
			Social.ShowAchievementsUI();
		else
			Social.localUser.Authenticate((bool success)=>{
				Social.ShowAchievementsUI();
			});
	}
	#endregion /Achievements
	#region Leaderboards
    // PRE: Leaderboard created in Google Play Developer and player is logged in
    // POST: Reports the score to the leaderboard id specified for Google Play
	public static void AddScoreToLeaderboard(string leaderboardId, long score)
	{
		Social.ReportScore(score, leaderboardId, success => { });
	}
    // PRE: Leaderboard created in Google Play Developer and player is logged in
    // POST: Accesses the PlayGamesScript to display the Leaderboard UI
	public static void ShowLeaderboardsUI()
	{
		if(PlayGamesPlatform.Instance.IsAuthenticated())
			Social.ShowLeaderboardUI();
		else
			Social.localUser.Authenticate((bool success)=>{
				Social.ShowLeaderboardUI();
			});
	}
	#endregion /Leaderboards
    }
