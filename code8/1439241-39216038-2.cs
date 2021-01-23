    [InitializeOnLoad]
    public class Startup {
    static Startup()
    {
        // unfortunately this is not available in NET 3.5
        // foreach (string file in Directory.EnumerateFiles.....
        foreach (string file in Directory.GetFiles("Assets", "Delete This File.txt", SearchOption.AllDirectories)) 
        {
             Debug.Log (file);
             // File.Delete(file);      
        }
    }
