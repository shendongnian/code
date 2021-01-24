    public partial class Form1 : Form
    {
        private Class1 change = new Class1();
        private void Form1_Load(object sender, EventArgs e)
        {
            change.ChangeLabel += Change_ChangeLabel;
        }
        private void Change_ChangeLabel(string lblName, string newValue)
        {
            Control[] matches = this.Controls.Find(lblName, true);
            if (matches.Length > 0 && matches[0] is Label)
            {
                Label lbl = (Label)matches[0];
                ChangeLabel(newValue, lbl);
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
