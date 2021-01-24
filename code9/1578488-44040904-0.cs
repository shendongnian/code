    private void btnIndex_Click(object sender, EventArgs e)
    {
        List<Graph> ObservingData = new List<Graph>(); // List to store all 
    
        using (StreamWriter sw = new StreamWriter("your new file.csv"))
        {
            // Loops through each lines in the CSV
            foreach (string line in System.IO.File.ReadAllLines(tbOutputFilePath.Text).Skip(1)) // .Skip(1) is for skipping header
            {
    
                string[] CsvLine = line.Split(',');
                Graph Instance1 = new Graph();
    
                Instance1.Date = DateTime.ParseExact(CsvLine[0], dateFormatString, CultureInfo.InvariantCulture);
                Instance1.StepTime = double.Parse(CsvLine[1]);
                Instance1.ModeDuration = double.Parse(CsvLine[2]);
                Instance1.Duration = int.Parse(CsvLine[3]);
                Instance1.ScheduleStep = int.Parse(CsvLine[4]);
                Instance1.Index = int.Parse(CsvLine[5]);
                Instance1.Mode = (CsvLine[6] == "TRUE" ? true : false);
    
                if (Instance1.ModeDuration != 0 || Instance1.Index != 2)
                {
                    sw.WriteLine(line);
    
                }
            }
    
            sw.Close();
        }
    
            
    }
