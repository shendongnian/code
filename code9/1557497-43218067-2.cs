    public partial class MainWindow : Window {
        Database db = new Database(@"database.txt", setLabel);
        public void setLabel(string s) {
            Vystup.Content = s;
        }
    }
    class Database {
        private Action<string> _onDoSomething = null
        public Database(string file, Action<string> onDoSomething) {
            this._onDoSomething = onDoSomething;
            ...
        }
        public void doSomething() {
            onDoSomething("hello");
        }
    }
