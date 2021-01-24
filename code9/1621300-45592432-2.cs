    var tempFile = Path.GetTempFileName(); //Creates temporary file                List<string> linesToKeep = new List<string>(); //Creates list of all the lines you want to keep (everything but your selection)
                using (FileStream fs = new FileStream(path(), FileMode.Open, FileAccess.Read)) //(this opens a new filestream (insert your path to your file there)
                {
                    using (StreamReader sr = new StreamReader(fs)) //here is starts reading your file line by line.
                    {
                        while (!sr.EndOfStream) //as long it has not finished reading
                        {
                            string currentline = sr.ReadLine().ToString(); //this takes the current line it has been reading
                            string splitline = currentline; //this is a temporary string because you are going to have to split the lines (i think you have 3 so split in "," and then index the first line (your identifier or name)))
                            if (splitline.Split(';')[0] != ID) //split the line and add your personal identifier so it knows what to keep and what to delete.
                            {
                                linesToKeep.Add(currentline); //adds the line to the temporary file list of line that you want to keep
                            }
                        }
                    }
                }
                File.WriteAllLines(tempFile, linesToKeep); //writes all the lines you want to keep back into a file
                File.Delete(path()); //deletes the old file
                File.Move(tempFile, path()); //moves temporary file to old location of the old file.
