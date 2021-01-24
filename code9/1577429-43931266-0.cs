    public void btExport_Click( object sender, EventArgs e )
    {
        if( IsValidFilename( textBox1.Text ) )
        {
            var dialogResult = folderBrowserDialog.ShowDialog();
        }
    }
