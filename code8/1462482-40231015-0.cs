    public void Main()
        {
            //$Package::SourceSQLObject = tablename
            //$Package::StageFile_DestinationFolderPath = rootpath eg "C:\temp\"
    
            string path = (string)Dts.Variables["$Package::StageFile_DestinationFolderPath"].Value;
            string name = (string)Dts.Variables["$Package::SourceSQLObject"].Value;
            string from = Path.Combine(path, name) + ".csv";
            string to = Path.ChangeExtension(from, "txt");
            Dts.Log("Starting " + to.ToUpper(), 0, null);
            using (StreamReader reader = new StreamReader(from, Encoding.ASCII, false, 10))
            using (StreamWriter writer = new StreamWriter(to, false, Encoding.UTF8, 10))
            {
                while (reader.Peek() >= 0)
                {
                    writer.WriteLine(reader.ReadLine());
                }
            }
            Dts.TaskResult = (int)ScriptResults.Success;
