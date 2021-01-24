    private void btnReverseString_Click(System.Object sender, System.EventArgs e)
    {
       string OriginalString = txtOriginalString.Text;
       string ReverseString = "";
       for (int i = OriginalString.Length; i >= 0; i--)
         {
            ReverseString += OriginalString[i];
         }
       txtReverseString.Text = ReverseString;
    }
