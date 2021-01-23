    class Program {
        const string listBoxName = "lb";
        [STAThread]
        static void Main(string[] args) {
            Window win = new Window();
            // create scope and associate it with Window
            NameScope.SetNameScope(win, new NameScope());
            ListBox lb = new ListBox();
            lb.Name = listBoxName;
            // register "lb" name
            win.RegisterName(listBoxName, lb);
            win.Content = lb;
            win.IsVisibleChanged += Win_IsVisibleChanged;
            Application app = new Application();
            app.Run(win);
        }
        private static void Win_IsVisibleChanged(Object sender,
            DependencyPropertyChangedEventArgs e) {
            if ((bool) e.NewValue) {
                Window win = sender as Window;
                var lb = win.FindName(listBoxName); // null
                Console.WriteLine(lb);
            }
        }
    }
