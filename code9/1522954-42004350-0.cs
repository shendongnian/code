            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(fullPath);
            while ((line = file.ReadLine()) != null)
            {
                if (counter == 0)//jump first row, it's header don't need it
                {
                    counter++;
                    continue;
                }
                if (line.Contains("EUR"))
                {
                    line = line.Replace(" ", "");//clean spaces
                    line = line.Substring(3 + 3 + 3 + 8, 8);
                Response.Write(line);
                }
                counter++;
                
            }
            file.Close();
            
