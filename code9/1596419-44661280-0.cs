    public class SelectList : Control, IGrid {
        public int Number { get; set; }
        public new string Text {
            get {
                return "Hello Select!";
            }
            // This is bad, someone after you may not know that this has a side effect
            set { Number = int.Parse(value); }
        }   
    }
