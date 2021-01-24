    interface IGithubHoster: IHoster
    {
    }
    class GithubHoster : IGithubHoster 
    {
        private readonly GithubConfigSourceValidator _validator = new GithubConfigSourceValidator();
        private readonly GithubHosterApi _api = new GithubHosterApi();
        private readonly GithubBackupMaker _backupMaker = new GithubBackupMaker();
        public IConfigSourceValidator Validator { get { return _validator; } }
        public IHosterApi Api { get { return _api; } }
        public IBackupMaker BackupMaker { get { return _backupMaker; } }
    }
    class GithubBackupMaker : IBackupMaker
    {
        public void Backup()
        {
            throw new NotImplementedException();
        }
    }
    class GithubHosterApi : IHosterApi
    {
        public IEnumerable<object> GetRepositoryList()
        {
            throw new NotImplementedException();
        }
    }
    class GithubConfigSourceValidator : IConfigSourceValidator
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
