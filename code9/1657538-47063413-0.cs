    public string Decrypt(string encryptedNumber)
    {
        string decCCNum = Convert.ToString((Convert.ToInt64(encryptedNumber) - 43) / 13);
        MessageBox.Show("Customer Name: " + FirstName + " " + LastName + "\n" + 
           "Encypted Card #: " + encryptedNumber + "\n" + 
           "Decrypted Card #: " + decCCNum , "Customer Info", 
           MessageBoxButtons.OK, MessageBoxIcon.Information);
    return decCCNum;
    }
