    var listOfFiles = new List<IFiles> // <-- List rather than Dictionary
    {
        new ImagesFiles(
            new List<ImagesFile>
            {
                new ImagesFile {path = "C:\\wf.n"},
                new ImagesFile {path = "C:\\wfz.n"}
            }
        ),
        new MediaFiles(
            new List<MediaFile>
            {
                new MediaFile {path = "C:\\wf.jpg", foo = 1},
                new MediaFile {path = "C:\\wfz.png", foo = 2}
            }
        )
    };
    foreach (var files in listOfFiles)
    {
        Console.WriteLine(files.resourceType); // <-- Gives Media / Image
        var fileshash = files.GetHashCode();
        foreach (IFile file in files.GetFiles())
        {
            var myPath = file.path;
            var hash = file.GetHashCode();
        }
    }
