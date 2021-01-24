    public class GithubHoster : IHoster<GithubHoster>
    {
        public GithubHoster(
            IConfigSourceValidator<GithubHoster> validator, 
            IHosterApi<GithubHoster> api, 
            IBackupMaker<GithubHoster> backupMaker)
        {
            if (validator == null)
                throw new ArgumentNullException("validator");
            if (api == null)
                throw new ArgumentNullException("api");
            if (backupMaker == null)
                throw new ArgumentNullException("backupMaker");
            this.Validator = validator;
            this.Api = api;
            this.BackupMaker = backupMaker;
        }
        public IConfigSourceValidator<GithubHoster> Validator { get; private set; }
        public IHosterApi<GithubHoster> Api { get; private set; }
        public IBackupMaker<GithubHoster> BackupMaker { get; private set; }
    }
    public class BitbucketHoster : IHoster<BitbucketHoster>
    {
        public BitbucketHoster(
            IConfigSourceValidator<BitbucketHoster> validator,
            IHosterApi<BitbucketHoster> api,
            IBackupMaker<BitbucketHoster> backupMaker)
        {
            if (validator == null)
                throw new ArgumentNullException("validator");
            if (api == null)
                throw new ArgumentNullException("api");
            if (backupMaker == null)
                throw new ArgumentNullException("backupMaker");
            this.Validator = validator;
            this.Api = api;
            this.BackupMaker = backupMaker;
        }
        public IConfigSourceValidator<BitbucketHoster> Validator { get; private set; }
        public IHosterApi<BitbucketHoster> Api { get; private set; }
        public IBackupMaker<BitbucketHoster> BackupMaker { get; private set; }
    }
