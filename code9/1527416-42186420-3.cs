	class GithubHoster : IHoster
	{
	    public GithubHoster(GithubConfigSourceValidator validator, GithubHosterApi api, GithubBackupMaker backupMaker)
	    {
	        this.Validator = validator;
	        this.Api = api;
	        this.BackupMaker = backupMaker;
	    }
	
	    public IConfigSourceValidator Validator { get; private set; }
	    public IHosterApi Api { get; private set; }
	    public IBackupMaker BackupMaker { get; private set; }
	}
