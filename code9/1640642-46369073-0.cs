    var myValueFromView = "56";
    string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
    string folderName = Path.Combine(projectPath, "images", myValueFromView);
    if(!System.IO.Directory.Exists(folderName))
        System.IO.Directory.CreateDirectory(folderName);
