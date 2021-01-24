    string folderToSplitOn = "DataFiles";
    
    // Split your input string to detect from which path to delete
    string path = @"C:\Export\DataFiles\20392\483928\292833\file1.txt";
    string[] splittedString = path.Split('\\');
    
    // Assuming you want to split from DataFiles, loop through your splitted results like this
    string pathToDeleteFrom = null;
    for (int i = 0; i < splittedString.Length; i++)
    {
        pathToDeleteFrom += splittedString[i] + @"\";
    
        // It's now equal to the folder you want to delete from. Add the extra folder and finish
        if (splittedString[i].Equals(folderToSplitOn))
        {
            pathToDeleteFrom += splittedString[i + 1] + @"\";
            break;
        }
    }
    
    // Now you can delete all files and subfolders
    Directory.Delete(pathToDeleteFrom, true);
