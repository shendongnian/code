    protected void rptDocumentsProposal_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandArgument == null)
            return;
    
        // I prefer to use switch/case here to handle more Buttons click easily
        // feel free to use if/else instead of switch/case
        switch (e.CommandName)
        {
            case "Download":
                // deal with the Button click here
                break;
    
            default:
                // hello !!, there is nothing to do with
                break;
        }
    }
