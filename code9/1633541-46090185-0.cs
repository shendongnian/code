    public class DialogInputEventArgs : EventArgs
    {
        public string Input { get; set; }
    }
    public partial class DialogWindow : Window
    {
        public event EventHandler<DialogInputEventArgs> InputChanged = delegate { };
        private void SubmitInputButton_Click(object sender, RoutedEventArgs e)
        {
            InputChanged(this, new DialogInputEventArgs() { Input = this._inputTextBox.Text });
        }
    }
