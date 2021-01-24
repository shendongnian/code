    private void PrefixOtherDataToClipboard()
    {
        StringBuilder str = new StringBuilder();
    
        //Replace appended strings with your corresponding variables
        str.Append("Purchaser\t" + "P1"); str.AppendLine("\tReject Reason\t" + "bla bla bla..");
        str.AppendLine("Date\t" + DateTime.Now);
        str.AppendLine("PR#\t" + "23432");
        str.AppendLine("Total Values\t" + "4234");
        str.AppendLine("Status\t" + "Waiting");
    
    
        str.AppendLine(Clipboard.GetText());
    
        Clipboard.SetText(str.ToString());            
    }
