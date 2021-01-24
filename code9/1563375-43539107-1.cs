    using ProjectLibrary;
    using System.Windows;
    namespace Sandbox {
    public partial class App : Application {
        MyWindow w;
        MyViewModel vm;
        public App() {
            w = new MyWindow();
            //You also can pass Action to open new window of some sort here
            //or other things, that VM can't have access to
            vm = new MyViewModel(true);
            w.DataContext = vm;
            w.Show();
        }
      }
    }
