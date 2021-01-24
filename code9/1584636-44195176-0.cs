    public interface IMainWindowProvider
    {
        Window GetMainWindow();
    }
    public class MainWindowProvider : IMainWindowProvider
    {
        public Window GetMainWindow() => Application.Current.MainWindow;
    }
