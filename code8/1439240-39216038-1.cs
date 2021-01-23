    [InitializeOnLoad]
    public class Startup {
    static Startup()
    {
        foreach (string file in Directory.EnumerateFiles("Assets", "Delete This File.txt", SearchOption.AllDirectories)) 
        {
             Debug.Log (file);
             // File.Delete(file);      
        }
    }
