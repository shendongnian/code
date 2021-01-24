    Microsoft.Win32.OpenFileDialog openfiledialog = new Microsoft.Win32.OpenFileDialog();
            openfiledialog.FileName = ""; // Default file name
            openfiledialog.DefaultExt = ".txt"; // Default file extension
            openfiledialog.Filter = "txt files (.txt)|*.txt"; // Filter files by extension
            // Show open file dialog box
            bool? result = openfiledialog.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                var fileName = openfiledialog.FileName;
                StreamReader file = new StreamReader(fileName);
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    var splitLine = line.Split(':');
                    if (splitLine.Count() > 1)
                    {
                        gambitCollection.Add(new Gambit() { GetID = splitLine[0].Trim(), GetDetails = splitLine[1].Trim() });
                    }
                }
            }
