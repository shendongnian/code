        private static void loadData1()
        {
            using (StreamReader labelReader = new StreamReader(outputFolder + @"\DATA\DFile1.txt"))
            {
                while (labelReader.Peek() > -1)
                {
                    string line = labelReader.ReadLine();
                    string[] dataArray = line.Split('|');
                    dataFile.AddRange(dataArray);
                }
            }
        }
