    string[] filesA = System.IO.Directory.GetFiles(AsourcePath);
    string[] filesB = System.IO.Directory.GetFiles(BsourcePath);
    foreach (string s in filesA)
    {
         System.IO.File.Move(s, AsourcePath);
    }
    foreach (string s in filesB)
    {
         System.IO.File.Move(s, BsourcePath);
    }
