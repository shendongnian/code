    public class FileWriter
    {
        private static ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();
        public void WriteData(string dataWh,string filePath)
        {
            lock_.EnterWriteLock();
            try
            {
                using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    byte[] dataAsByteArray = new UTF8Encoding(true).GetBytes(dataWh);
                    fs.Write(dataAsByteArray, 0, dataWh.Length);
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }
        }
    }
