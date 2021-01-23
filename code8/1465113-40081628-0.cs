    try
            {
                System.IO.DirectoryInfo directory = new DirectoryInfo(@"Your local Image directory inside bin/debug");
                FileInfo result = null;
                var list = directory.GetFiles(); // Stackoverflow Exception occurs here
                if (list.Count() > 0)
                {
                    result = list.OrderByDescending(f => f.LastWriteTime).First();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
