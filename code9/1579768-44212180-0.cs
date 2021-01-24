    using System.IO;
    string path = Path.Combine(Application.persistentDataPath, "MyFile.txt");
    using (TextWriter writer = File.CreateText(path))
    {
        // TODO write text here
    }
