        private void printPreviewDialog1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Don't close and dispose the form if the user is just dismissing it. Hide instead.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                printPreviewDialog1.Hide();
            }
        }
