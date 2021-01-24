    public class DictionaryViewModel {
    
        // This will be a INotify based property in your VM
        public List<DictionaryEntryModel> DictionaryEntries { get; set; }
    
        public DictionaryViewModel () {
            DictionaryEntries = new List<DictionaryEntryModel>();
            
            // Create a parser with the [;] delimiter
            var textFieldParser = new TextFieldParser(new StringReader(File.ReadAllText(filePath)))
            {
                Delimiters = new string[] { ";" }
            };
            
            while (!textFieldParser.EndOfData)
            {
                var entry = textFieldParser.ReadFields();
                DictionaryEntries.Add(new DictionaryEntryModel()
                    {
                        Word = entry[0],
                        Language = entry[1],
                        Description = entry[2]
                    });
            }
            // Don't forget to close!
            textFieldParser.Close();
        }
    }
