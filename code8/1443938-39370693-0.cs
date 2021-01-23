        public void WriteAllTestScenarioNames(List<ScenarioResult> results, string fileName, string directoryName)
    {
        results.Sort();
        Directory.CreateDirectory(rootFolderPath + directoryName);
        string filePath = rootFolderPath + directoryName + @"\" + fileName;
        FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
		using (System.IO.StreamWriter file = new System.IO.StreamWriter(fs))
        {
            file.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            foreach (var scenarioResult in results)
            {
                file.WriteLine(scenarioResult.ToString());
            }
        }
        fs.Close();
        
    }
