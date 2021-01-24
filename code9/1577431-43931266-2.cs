    public bool IsValidFilename(string exportName)
    {
        var regex = new Regex(@"[^a-zA-Z0-9\s]");
        if (regex.IsMatch(exportName)) 
        {
            MessageBox.Show("Enter only valid characters! (Aa-Zz, 0-9)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //If this is the location of the error, put return false here.
            return false;
        };
        return true;
    }
