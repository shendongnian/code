	public void Main()
	{
        System.IO.StreamReader reader = null;
        try
        {
            Dts.Variables["User::FileIsValid"].Value = false;
            reader = new System.IO.StreamReader(Dts.Variables["User::Filepath"].Value.ToString());
            string header = reader.ReadLine();
            if (header.Trim() == "Column1\tColumn2\tColumn3\tColumn4\tColumn5\tColumn6")
                Dts.Variables["User::FileIsValid"].Value = true;
            reader.Close();
            reader.Dispose();
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        catch
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
            throw;
        }
	}
