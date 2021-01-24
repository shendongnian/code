    var Vehicles = new List<Vehicle>();
    if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
        using (var inputFile = File.OpenText(openFile.FileName)) {
            while (!inputFile.EndOfStream) {
                var v = new Vehicle {
                    Model = inputFile.ReadLine(),
                    Manufacturer = inputFile.ReadLine(),
                    Year = inputFile.ReadLine(),
                    VIN = inputFile.ReadLine()
                };
                Vehicles.Add(v);
            }
        } // The using statement closes the file automatically here.
        // Fill the listbox;
        vinCBox.DataSource = Vehicles;
    }
