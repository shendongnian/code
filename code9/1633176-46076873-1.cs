    `protected void btnAddChapter_Click(object sender, EventArgs e)
        {
            if (ddlSelectDocumentTitle.SelectedItem.Value != "0")
            {
                int res = AddChapterSelect(txtSubChapterNumber.Text, txtSubChapterTitle.Text, ddlChapter_Popup.SelectedValue);
                if (res > 0)
                {
                    lblSelectMsg.ForeColor = Color.Green;
                    lblSelectMsg.Text = "Record saved successfully";
                    txtChapterNumber.Text = "";
                    txtChapterTitle.Text = "";
                    txtSubChapterNumber.Text = "";
                    txtSubChapterTitle.Text = "";
                    Bind_ddlChapter();
                }
            }
            else
            {
                lblSelectMsg.ForeColor = Color.Green;
                lblSelectMsg.Text = "Please select document title";
            }
        }`
