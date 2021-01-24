    private void Form1_Load(object sender, EventArgs e)
    {
    string message = String.Empty;
    // populate the textboxes
    try
    {
         message = GetConfigValue("LinkedServerName");
         txtLinkedServer.Text = message
    }
    catch (Exception ex)
    {
         if (!String.IsNullOrEmpty(message))
            lblFeedback.Text = message;
         else
            lblFeedback.Text = ex.Message;
    }
    // do the same for the database here
}
