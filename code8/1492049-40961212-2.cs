            string[] existingTargetFiles = Directory.GetFiles(targetDir);
            // Get existing directories in destination
            string[] existingTargetDirectories = System.IO.Directory.GetDirectories(targetDir);
            // Compare and delete directories that exist in destination but not source
            foreach (string existingDirectory in existingTargetDirectories)
            {
                if (!Directory.Exists(Path.Combine(sourceDir, Path.GetFileName(existingDirectory))))
                {
                    Directory.Delete(Path.Combine(targetDir, existingDirectory),true);
                }
            }
            // Compare and delete files that exist in destination but not source
            foreach (string existingFiles in existingTargetFiles)
            {
                if (!File.Exists(Path.Combine(sourceDir, Path.GetFileName(existingFiles))))
                {
                    File.Delete(Path.Combine(targetDir, existingFiles));
                }
            }
        
