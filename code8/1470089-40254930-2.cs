    public interface ISaveData
    {
        void DeleteFile(); // this is common method
    }
    public interface IPermission
    {
        void AssignPermission();
    }
    public interface IBucketOperation //or something else
    {
        void ChangeBucket();
    }
    public class AzureSaveData : ISaveData, IBucketOperation 
    {
        public void ChangeBucket()
        {
            Console.WriteLine("AzureSaveData ChangeBucket");
        }
        public void DeleteFile()
        {
            Console.WriteLine("AzureSaveData DeleteFile");
        }
    }
    public class GoogleCloudSaveFile : ISaveData, IPermission
    {
        public void AssignPermission()
        {
            Console.WriteLine("GoogleCloudSaveFile AssignPermission");
        }
        public void DeleteFile()
        {
            Console.WriteLine("GoogleCloudSaveFile DeleteFile");
        }
    }
