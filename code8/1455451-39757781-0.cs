    /*We deprecate the old one by marking it obsolete*/
    [Obsolete("Use NewSaveGameFile instead")]
    public class OldSaveGameFile
    {
    	public int SomeInt { get; set; }
    }
    
    /*We extend by creating a new class with old one's fields*/
    /*and the new one's fields as nullables*/
    public class NewSaveGameFile
    {
    	public int SomeInt { get; set; }
    	public bool? SomeNullableBool { get; set; }
    }
    public class FileLoader
    {
    	public SavedGame LoadMyFile()
    	{
    		NewSaveGameFile newFile = GetFileFromDatabase(); // Code to load the file
    		if (newFile.SomeNullableBool.HasValue)
    		{
    			// You're good to go
    		}
    
    		else
    		{
    			// It's missing this property, so set it to a default value
    		}
    	}
    }
