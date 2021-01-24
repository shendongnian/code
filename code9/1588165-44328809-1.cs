    foreach (string line in System.IO.File.ReadAllLines(tbOutputFilePath.Text).Skip(1)) // .Skip(1) is for skipping header
    {
    	// here line stands for each line in the CSV file
    
    	string[] InCsvLine = line.Split(',');
        //init Marks class
        Marks statusInt = new Marks();
    
    	statusInt.Mark0 = (InCsvLine[2] == "TRUE" ? true : false);
    	statusInt.Mark1 = (InCsvLine[3] == "TRUE" ? true : false);
    	statusInt.Mark2 = (InCsvLine[4] == "TRUE" ? true : false);
    	statusInt.Mark3 = (InCsvLine[5] == "TRUE" ? true : false);
    
    	//add line read from csv to colletion
    	ObservingData.Add(statusInt);
    }
    
    //instead of if (statusInt.Mark0 == false), if (statusInt.Mark1 == false) etc, add this
    checkBox1.Enabled = ObservingData.Any(m => m.Marks0);
    checkBox2.Enabled = ObservingData.Any(m => m.Marks1);
    checkBox3.Enabled = ObservingData.Any(m => m.Marks2);
    checkBox4.Enabled = ObservingData.Any(m => m.Marks3);
