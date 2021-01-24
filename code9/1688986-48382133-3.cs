    List<string> files = new List<string>() { "123_novica_file1", "123_novica_file3" , "123_novica_file2" ,
                "456_myfilename_file1","789_myfilename_file1","101_novica_file2","102_novica_file3"};
    
                List<string> filesbyID = new List<string>();
                List<string> filesbyName = new List<string>();
    
                string theIDPattern = "123";
                string theFileNamePattern = "myfilename";
    
                foreach(var file in files)
                {
                    //splitting the filename and checking by ID
                    if(file.Split('_')[0].Contains(theIDPattern))
                    {
                        filesbyID.Add(file);
                    }
    
                    //splitting the filename and checking by name
                    if (file.Split('_')[1].Contains(theFileNamePattern))
                    {
                        filesbyName.Add(file);
                    }
                }
