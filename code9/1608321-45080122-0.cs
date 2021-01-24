        string line;
        System.IO.StreamReader fileIn;
        System.IO.StreamWriter fileOut = null;
        fileIn = new System.IO.StreamReader(inputFile);
        while ((line = fileIn.ReadLine()) != null)
        {
            if (line.Length > 0 && line.Substring(0, 1) == "O")
            {
                _parent.StatusOutput(line);
                if (fileOut != null)
                {
                    // close the existing file ...
                    fileOut.WriteLine();
                    fileOut.WriteLine();
                    fileOut.WriteLine("%");
                    fileOut.Close();
                }
                // create a new file ...
                fileOut = new System.IO.StreamWriter(outputFolder + @"\" + line);
                fileOut.WriteLine();
                fileOut.WriteLine("%");
                fileOut.WriteLine(line);
