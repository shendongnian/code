        try 
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader("TestFile.txt")) 
                    {
                        string line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null) 
                        {
                            //your code goes here
                    string[] sPlit = line.Split(',');
                    univ[i].uni = sPlit[0];
                    univ[i].prov = sPlit[1];
                    univ[i].city = sPlit[2];
                    univ[i].population = sPlit[3];
                    univ[i].programs = sPlit[4];
                    univ[i].tuition = sPlit[5];
                    univ[i].residence = sPlit[6];
                    comboBox1.Items.Add(univ[i].uni);
                        }
                    }
                }
                catch (Exception p) //catches errors
            {
                Console.WriteLine("Exception: " + p.Message);
            }
            finally //final statement before closing
            {
                Console.WriteLine("Executing finally block.");
            }
    
    Hope Helps
