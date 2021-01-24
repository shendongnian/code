    public class ApplicationConfiguration
    {
         public DatabaseConfiguration Database { get; } = new DatabaseConfiguration();
         public StorageConfiguration Storage { get; } = new StorageConfiguration();
    }
    
    public class DatabaseConfiguration
    {
         public string ConnectionString { get; set; }
    }
    
    public class StorageConfiguration
    {
         public string TemporalFileDirectoryPath { get; set; }
         public string BinaryDirectoryPath { get; set; }
    }
