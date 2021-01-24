       public class MyFolder
        {
            string folderName { get; set;}
            List<MyFolder> childFolders { get; set; }
            Dictionary<string, List<byte>> files { get; set; }
        }
