    public partial class SubForm : Form
    {
        public void SetExampleText(string text)
        {
            this.InvokeAction(() => { this.ExampleTextBox.Text = text; })
        }
    }
