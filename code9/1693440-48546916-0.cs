    class Program {
        static void Main(string[] args) {
            CollectionHandler.origFileList.Add("Value 1");
            CollectionHandler.origFileList.Add("Value 2");
            CollectionHandler.origFileList.RemoveAt(1);
            CollectionHandler.origFileList.RemoveAt(0);
            CollectionHandler.origFileList.Add("Test Value #1");
            CollectionHandler.origFileList.Add("Test Value #2");
            Console.Read();
        }
    }
    public static class CollectionHandler {
        private static rrList _origFileList = new rrList();
        public static rrList origFileList {
            get {
                return _origFileList;
            }
            set {
                _origFileList = value;
            }
        }
    }
    public class rrList {
        private List<string> _origFileList = new List<string>();
        private void myTestCallback() {
            Console.WriteLine("List Is now empty");
        }
        private void ListChanged() {
            Console.WriteLine("List Size: " + _origFileList.Count);
        }
        public void RemoveAt(int i) {
            _origFileList.RemoveAt(i);
            checkList();
        }
        public void Add(string stringToAdd) {
            _origFileList.Add(stringToAdd);
            checkList();
        }
        private void checkList() {
            if (_origFileList.Count == 0) {
                myTestCallback();
            } else {
                ListChanged();
            }
        }
    }
