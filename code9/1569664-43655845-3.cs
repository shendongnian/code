    public interface ICommonCalls {
        string PubUpdateFileCDSPath { get; }
        string PubUpdateFileLocalPath { get; }
    }
    public interface IDiskDeliveryDAO {
        int TrackPublicationChangesOnCDS(List<string> pubRecordsExceptToday);
    }
    public interface IFileSystem {
        bool Exists(string path);
        void Copy(string sourceFilePath, string destinationFilePath, bool overwrite);
        string[] ReadAllLines(string path);
        void WriteAllText(string path, string contents);
        void WriteAllLines(string path, IEnumerable<string> contents);
    }
