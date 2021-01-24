    private void button1_Click(object sender, EventArgs e)
    {
        string fullName = "Jean Claude Van Dam";
        fullName = fullName.Trim();
        // So we split it down into tokens, using " " as the delimiter
        string[] names = fullName.Split(' ');
        string strFormattedMessage = "";
        // How many tokens?
        int iNumTokens = names.Length;
        // Iterate tokens
        for(int iToken = 0; iToken < iNumTokens; iToken++)
        {
            // We know the token will be at least one letter
            strFormattedMessage += Char.ToUpper(names[iToken][0]);
            // We can't assume there is more letters (they might have used an initial)
            if(names[iToken].Length > 1)
            {
                // Add them (make it lowercase)
                strFormattedMessage += names[iToken].Substring(1).ToLower();
                // Don't need to add "\n\n" for the last token
                if(iToken < iNumTokens-1)
                    strFormattedMessage += "\n\n";
            }
            // Note, this does not take in to account names with hyphens or names like McDonald. They would need further examination.
        }
        if(strFormattedMessage != "")
        {
            MessageBox.Show(strFormattedMessage);
        }
    }
