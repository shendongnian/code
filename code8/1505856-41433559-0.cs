    public class ComboBoxItemForPathAndFileName
    {
        public ComboBoxItemForPathAndFileName(string fileName, string fullPathAndFileName)
        {
            this.FileName = fileName;
            this.FullPathAndFileName = fullPathAndFileName;
        }
        public string FileName{get;set;} = string.Empty;
        public string FullPathAndFileName{get;set;} = string.Empty;
        public override ToString()
        {
            return this.FileName;
        }
    }
