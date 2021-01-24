      public void loggeneration(DateTime datetime, string projectname, int totallines, int sum, int max)
        {
            // this is the variable to your xls file 
            string path = @"c:\temp\log.xls";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    //once file was created insert the columns
                    sw.WriteLine("date;projectname;totallines;sum;max");
                    
                }
            }
            // This text is always added, making the file longer over time
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(String.Format("{0};{1};{2};{3};{4}", datetime, projectname, totallines, sum, max));
            }
        }
