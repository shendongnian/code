    public sealed class CodeLibrary
    {
        public int CodeGroupNumber { get; set; }
        public string CodeGroupName { get; set; }
        public List<Codes> CodeList { get; set; }
    
        private Codes _selectedCodes;
        public Codes SelectedCodes { 
            get { return _selectedCodes; }
            set {
                if (value != _selectedCodes) {
                    _selectedCodes = value;
                    //  Do other stuff here if you want
                    MessageBox.Info("You selected " + _selectedCodes.Code);
                }
            }
        }
    }
