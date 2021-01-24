    private new void Enter(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == Convert.ToChar(Keys.Enter))
        {
            Commands.OnCommand(this);
    public static void OnCommand(Form1 frm)
    {
        if (frm.code.Text.Contains("end") && frm.code.TextLength == 4)
        {
