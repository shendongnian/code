    public partial class MainWindow : Window {
        Database db = new Database(@"database.txt");
        public void setLabel(string s) {
            Vystup.Content = s;
        }
        public void SomeDatabaseThing()
        {
            string returnValue = db.doSomething();
            setLabel(returnValue);
        }
    }
    class Database {
        public Database(string file) {
            ...
        }
        public string doSomething() {
            return "hello";
        }
    }
