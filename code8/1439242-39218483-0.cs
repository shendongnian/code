    using UnityEngine;
    using UnityEditor;
    using System.IO;
    
    [InitializeOnLoad]
    public class Startup 
    {
        static Startup()
        {
            ProcessDirectory("Assets/");
        }
    
        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string filePath in fileEntries)
            {
                FileInfo fileInfo = new FileInfo(filePath);
    
                if (fileInfo.Name == "Delete This File.txt")
                {
                    ProcessFile(filePath);
                }
            }
    
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory);
            }
        }
    
        // Insert logic for processing found files here.
        public static void ProcessFile(string path)
        {
            Debug.Log("Processed file " + path);
    
            //Delete File
            File.Delete(path);
        }
    }
