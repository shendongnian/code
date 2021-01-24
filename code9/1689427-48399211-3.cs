    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    ...
    static void Main(string[] args)
    {
        var USERNAME = Environment.UserName;
        string START_DIRECTORY = @"C:\Users\" + USERNAME + "\\Desktop\\START";
        string END_FOLDER_STRING = @"C:\Users\" + USERNAME + "\\Desktop\\END";
        IEnumerable<string> startFiles = Directory.GetFiles(START_DIRECTORY);
        IEnumerable<string> endFiles = Directory.GetFiles(END_FOLDER_STRING);
        foreach(string file in startFiles.Intersect(endFiles, new FileNameEqualityComparer()))
        {
            File.Copy(file, "[the path to the folder where they should be copied]");
        }
    }
