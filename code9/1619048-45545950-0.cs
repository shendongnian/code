    private static Object thisLock = new Object();
    lock (thisLock)
    {
        System.IO.File.AppendAllText(FilePath + @"\" + "DandB" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt", DataToBeSave + Environment.NewLine);
    }
