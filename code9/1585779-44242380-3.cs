    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            Class1 change = new Class1();
            change.ChangeLabel += Change_ChangeLabel;
            change.ChangeLabelText();
        }
        private void Change_ChangeLabel(string lblName, string newValue)
        {
            // see if we have a Label with the desired name:
            Control[] matches = this.Controls.Find(lblName, true);
            if (matches.Length > 0 && matches[0] is Label)
            {
                Label lbl = (Label)matches[0];
                ChangeLabel(newValue, lbl); // update it in a thread safe way
            }
        }
        private void ChangeLabel(string msg, Label label)
        {
            if (label.InvokeRequired)
                label.Invoke(new MethodInvoker(delegate { label.Text = msg; }));
            else
                label.Text = msg;
        }
    }
