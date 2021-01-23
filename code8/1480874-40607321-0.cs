    foreach (string sp in searchPatterns)
        {
            try
            {
                files.AddRange(System.IO.Directory.GetFiles(path, sp, searchOption));
            }
            catch (UnauthorizedAccessException UAEx)
            {
                MessageBox.Show(UAEx.Message);
                continue;
            }
            catch (PathTooLongException ex)
            {
                MessageBox.Show(ex.Message);
                continue;
            }
        }
