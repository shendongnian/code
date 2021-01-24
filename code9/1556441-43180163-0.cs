    public void LoadFile() {
        var outputDocument = new XDocument();
        var inventory = new XElement("Inventory");
        outputDocument.Add(inventory);
        using (var fstream = File.OpenRead(FilePathProducts))
        using (var fileReader = new StreamReader(fstream)) {
            while (!fileReader.EndOfStream) {
                var readLine = fileReader.ReadLine();
                var words = readLine.Split(';');
                inventory.Add(
                    new XElement("Item",
                        new XElement("Name", words[1]),
                        new XElement("Count", words[3]),
                        new XElement("Price", words[4]),
                        new XElement("Comment", "<Missing Value>"),
                        new XElement("Artist", "<Missing Value>"),
                        new XElement("Publisher", "Nintendo"),
                        new XElement("Genre", "<Missing Value>"),
                        new XElement("Year", words[0]),
                        new XElement("ProductID", words[2])
                    )
                );
            }
        }
        outputDocument.Save(FilePathResult);
    }
