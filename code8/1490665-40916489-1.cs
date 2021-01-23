    string root = @"\\Users\none\Documents\File Sorter";
    string[] directories = Directory.GetDirectories(root);
    var dirRef = directories.ToDictionary(k => k.Split('-')[1], v => v);
    string[] files = Directory.GetFiles(root);
    foreach (var file in files)
    {
        string fileName = Path.GetFileName(file);
        string projectName = null;
        foreach (Match m in Regex.Matches(fileName, "[A-Za-z0-9]+(?=-)"))
        {
            if (projectName == null)
            {
                projectName = m.Value;
            }
            else if (projectName != m.Value)
            {
                projectName = null;
                break;
            }
        }
        if (projectName == null)
        {
            Console.WriteLine("Project names in file {0} do not match.", fileName);
        }
        else if (dirRef.ContainsKey(projectName))
        {
            File.Move(file, dirRef[projectName] + "\\" + fileName);
            Console.WriteLine("File {0} moved to directory {1}.", fileName, dirRef[projectName]);
        }
        else
        {
            Console.WriteLine("Directory with project name {0} doesn't exist", projectName);
        }
    }
