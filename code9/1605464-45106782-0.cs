    public class FileTypeA : File
    {
        public Header H {get;set;}
        public Float X {get;set;}
        
        // constructor:
        public FileTypeA(byte[] givenData, string givenPath) : base(givenData, givenPath)
        {
            X = new Float(...);
            // watch for changes to the property:
            X.PropertyChanged += MetaChanged;
		}
        // gets called when the aforementioned watched properties change:
		private void MetaChanged(object sender, PropertyChangedEventArgs e)
		{
			H.UpdateCRC(Encode(...), ...);
		}
    }
