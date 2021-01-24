    private new void Enter(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == Convert.ToChar(Keys.Enter))
        {
            string message = Commands.OnCommand(code.Text);
            if (message == "")
            {
                Close();
            }
            else
            {
                frm.output.Text = frm.output.Text + message;
                frm.code.Clear();
            }
                
    public static void OnCommand(string code)
    {
        if (code.Contains("end") && code.Length == 4)
        {
            if (MessageBox.Show("Close?", "Close window?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                return "";
            else
                return "Closing closed";
        }
        else
        {
            MessageBox.Show("test");
            return "I don't understand ... ";
        }
