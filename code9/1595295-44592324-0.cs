    public class FileInFileOutTasks
    {
        public FileInFileOutTasks()
        {
        }
        public void RunExecute(FileIn fileIn, FileOut, fileout)
        {
            var scheduler = new FileInFileOut { FileIn = fileIn, FileOut = fileOut };
            scheduler.Execute();
        }
    }
