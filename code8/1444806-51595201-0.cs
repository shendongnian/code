       public void Main()
    {
        String FilePath = Dts.Variables["UserControl::File"].Value.ToString();
            if (File.Exists(FilePath))
                {
                     File.Delete(FilePath);
                }
        Dts.TaskResult = (int)ScriptResults.Success;
    }
