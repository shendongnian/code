    public class A
    {
            private static string systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            private string path = Path.Combine(systemPath, "TextDynamic.txt");
            private string labelPath = Path.Combine(systemPath, "currentLabel.txt");
            private string objectPath = Path.Combine(systemPath, "object.txt");
    }
    
     
