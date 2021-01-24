    private void settingsForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                if(e.CloseReason != CloseReason.UserClosing)
                {
                    e.Cancel = true;
                }
            }
