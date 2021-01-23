    public class FileSheetParameters
    {
        public FileSheetParameters()
        {
            SheetExists = false;
            IsPlaceholder = false;
            pArray = new List<string>();
        }
        public bool SheetExists { get; set; }
        public bool IsPlaceholder { get; set; }
        public List<string> pArray { get; set; }
    }
