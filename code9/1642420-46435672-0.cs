    using System.IO;
    private void cmdCheck_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtInput.Text))
            {
                // This is a directory, not a file.
                // TODO: Do things to tell the user that's a directory, not a file, duh!
            }
            else if (Path.HasExtension(txtInput.Text))
            {
                // This is a file, not a directory.
                if (File.Exists(txtInput.Text))
                {
                    // This file exists.
                    // TODO: Logic to tell the user the file exists.
                }
                else
                {
                    // This file doesn't exist.
                    // TODO: Do things if the file doesn't exist.
                }
            }
        }
