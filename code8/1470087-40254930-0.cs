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
        void ChangeBucket()
        {...}
    
        void DeleteFile()
        {...}
    }
    
    public class GoogleCloudSaveFile() : ISaveData, IPermission
    {
        void AssignPermission()
        {...}
        void DeleteFile()
        {.....}
    }
