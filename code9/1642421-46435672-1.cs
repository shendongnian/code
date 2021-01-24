    using System.IO;
    private void cmdCheck_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtInput.Text))
            {
                // This is a directory, not a file.
            }
            else
            {
                try
                {
                    if (File.Exists(txtInput.Text))
                    {
                        var fileInfo = new FileInfo(txtInput.Text);
                        // File exists and now we have the information.  Alert the user.
                    }
                    else
                    {
                        // File doesn't exist.  Do things.
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message, "ERROR");
                }
            }
        }
