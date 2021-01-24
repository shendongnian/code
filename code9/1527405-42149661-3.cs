    [HosterAttribute(typeof(IGithubHoster))]
    class GithubBackupMaker : IBackupMaker
    {
        public void Backup()
        {
            throw new NotImplementedException();
        }
    }
    [HosterAttribute(typeof(IGithubHoster))]
    class GithubHosterApi : IHosterApi
    {
        public IEnumerable<object> GetRepositoryList()
        {
            throw new NotImplementedException();
        }
    }
    [HosterAttribute(typeof(IGithubHoster))]
    class GithubConfigSourceValidator : IConfigSourceValidator
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
