            // Get existing files in destination
            string[] existingTargetFiles = Directory.GetFiles(targetDir, "*.*", SearchOption.AllDirectories);
            // Get existing directories in destination
            string[] existingTargetDirectories = Directory.GetDirectories(targetDir, "*", SearchOption.AllDirectories);
            // Compare and delete files that exist in destination but not source
            foreach (string existingFiles in existingTargetFiles)
            {
                if (!File.Exists(existingFiles.Replace(targetDir, sourceDir)))
                {
                    File.Delete(existingFiles);
                }
            }
            // Compare and delete directories that exist in destination but not source
            foreach (string existingDirectory in existingTargetDirectories)
            {
                if (!Directory.Exists(existingDirectory.Replace(targetDir, sourceDir)))
                {
                    Directory.Delete(existingDirectory,true);
                }
            }
        
