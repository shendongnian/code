     StreamReader inputFile;
        int i = 0, count=Vehicles.Length;
        if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            inputFile = File.OpenText(openFile.FileName);
            while (!inputFile.EndOfStream)
            {
                Vehicles[i].Model = inputFile.ReadLine();
                Vehicles[i].Manufacturer = inputFile.ReadLine();
                Vehicles[i].Year = inputFile.ReadLine();
                Vehicles[i].VIN = inputFile.ReadLine();
                i++;               
                
             }
            for (int j = 0; j < i; j++)
            {
                 vinCBox.Items.Add(Vehicles[j].VIN);
            }
         }
