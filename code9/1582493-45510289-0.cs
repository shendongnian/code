      /// <summary>
        ///     Tries to open the file for R/W to see if its lock. Returns Boolean
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>bool</returns>
        protected static bool IsFileLocked(string filePath)
            {
            FileStream stream = null;
            var file = new FileInfo(filePath);
            try
                {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
            catch (IOException err)
                {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
                }
            finally
                {
                stream?.Close();
                }
            //file is not locked
            return false;
            }
