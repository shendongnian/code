    public interface IHoster<THoster>
    {
        IConfigSourceValidator<THoster> Validator { get; }
        IHosterApi<THoster> Api { get; }
        IBackupMaker<THoster> BackupMaker { get; }
    }
    public interface IConfigSourceValidator<THoster>
    {
        void Validate();
    }
    public interface IHosterApi<THoster>
    {
        IList<string> GetRepositoryList();
    }
    public interface IBackupMaker<THoster>
    {
        void Backup();
    }
