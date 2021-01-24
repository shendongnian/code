    public class Echemicals {
        private int index;
        private Echemicals(int index) {
            this.index = index;
        }
        public static Echemicals _Oxygen = new Echemicals(1);
        public static Echemicals Oxygen { get { return _Oxygen; } }
        // Other elements
        // A list of all values:
        public static Echemicals[] _Values;
        public static Echemicals[] Values { get { return _Values; } }
        
        static Echemicals() {
            _Values = new[] {Oxygen, /*other elements*/};
        }
        static Echemicals GetByIndex(index) {
            return Values.FirstOrDefault(e => e.index == index);
        }
    }
