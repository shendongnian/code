     public void findAll()
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filename);
    
                //Read the first line of text
                line = sr.ReadLine();
    
                //Continue to read until you reach end of file
                while (line != null)
                {
                    var text = line.Split(',');
                    string n = text[0];
                    string c = text[1];
                    int p = Convert.ToInt32(text[2]);
                    countries.Add(new country(n, c, p));  //store each country
                    line = sr.ReadLine();
                }
            }
