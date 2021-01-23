    using (FileStream aFile = new FileStream(path, FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                while ((line = reader.ReadLine()) != null)
                {                       
                    var delimiter = string.Empty; 
                    string[] tokens = line.Split(new char[] { ' ', '\t', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if(tokens.hasNext())
                    { delimiter = ","; }
                    else 
                    { delimiter = "."; }
                    if (tokens[1].Equals(ColChangable1) || tokens[1].Equals(ColChangable2))
                    {
                        sw.WriteLine(tokens[0] + "\t" + "\"TRIM(:" + tokens[0] + ")\" + delimiter);
                    }
                    else if (tokens[1].Equals(ColChangable3))
                    {
                        sw.WriteLine(tokens[0] + "\t" + delimiter);
                    }
                    else if (tokens[1].Equals(ColChangable4))
                    {
                        sw.WriteLine(tokens[0] + "\t" + "DATE" + delimiter);
                    }                        
                }
            }                
        }
    }
