            string extention = ".txt";
            string originalFileName = string.Format("test{0}", extention);
            string duplicateFileName = "test";
            string changedName = duplicateFileName;
            int count = 1;
            while (File.Exists(changedName + extention))
            {
                changedName = string.Format("{0} - Copy ({1})",
                    duplicateFileName, count++);
            }
            File.Copy(originalFileName, changedName + extention);
