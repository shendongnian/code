    public static void btnSummary_Click(object sender, EventArgs e)
        {
            string currentText = lblUsers.Text;
            int positionOfLastEntry = currentText.LastIndexOf("Name:");
            string textWithoutLastEntry = currentText.Substring(0, positionOfLastEntry);
            lblUsers.Text = textWithoutLastEntry;
            lblUsers.Visible = true;
        }
