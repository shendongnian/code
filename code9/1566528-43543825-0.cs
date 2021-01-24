    public interface IDialogService
    {
        void ShowDialog(string title, string message);
    }
    public class DialogService : IDialogService
    {
        public void ShowDialog(string title, string message)
        {
            //implement your actual dialog however you want there...
            System.Windows.MessageBox.Show(message, title);
        }
    }
