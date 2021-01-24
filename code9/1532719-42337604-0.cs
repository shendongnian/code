     List<string> lstResult = new List<string>();
            using (StreamReader sr = new StreamReader(@"C:\Stack\file.txt"))
            {
                
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    //Here I am getting the second part of splitted string which is your requirement
                    lstResult.Add(line.Split(':').Select(x=>x).Skip(1).SingleOrDefault().ToString());    
                }
            }
            comboBox1.DataSource = lstResult;
