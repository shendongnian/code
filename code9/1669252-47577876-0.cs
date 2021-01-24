    private string GetReleases(string username, string repoName)
    	{
    		const string GITHUB_API = "https://api.github.com/repos/{0}/{1}/releases";
    		WebClient webClient = new WebClient();
            // Added user agent
    		webClient.Headers.Add("User-Agent", "Unity web player");
    		Uri uri = new Uri(string.Format(GITHUB_API, username, repoName));
    		string releases = webClient.DownloadString(uri);
    		return releases;
    	}
