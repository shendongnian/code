    System.IO.FileInfo fileInfo = new FileInfo("filename.file");
    var fileDirectory = fileInfo.DirectoryName;
    var fileName = fileInfo.Name;
    var fileExtension = fileInfo.Extension;
    var filePathandFileNameBoth = fileInfo.FullName;
    
    Console.WriteLine("filePathandFileNameBoth: ");
    Console.WriteLine(filePathandFileNameBoth);
    Console.WriteLine("-");
    Console.WriteLine("fileDirectory:");
    Console.WriteLine(fileDirectory);
    Console.WriteLine("-");
    Console.WriteLine("fileName:");
    Console.WriteLine(fileName);
    Console.WriteLine("-");
    Console.WriteLine(filePathandFileNameBoth == fileDirectory + "\\" + fileName ? fileExtension : "I'm totally wrong");
    Console.ReadLine();
