    public partial class MainWindow : Window {
        Database db = new Database(this, @"database.txt");
        public void setLabel(string s) {
            Vystup.Content = s;
        }
    }
    class Database {
        private MainWindow _mainWindow { get; set; }
        public Database(MainWindow window, string file) {
            this._mainWindow = window;
            ...
        }
        public void doSomething() {
            _mainWindow.setLabel("hello");
        }
    }
