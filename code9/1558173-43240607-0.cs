    using (StreamReader rd = new StreamReader(calendarEntriesFile))
    {
            string line = rd.ReadLine();
            while (line != null)// read line by line in file all apointments
            {
                string[] data = line.Split('#');
                Row row = new Row();
                row.Adopt(data);//create a row of current line i.e appointment
                this.Add(row); // add it to the current list for display
                line = rd.ReadLine();
            }
    }
