    #region mnuHelp ---------------------------------------------
    private void mnuHelpContents_Click(object sender, EventArgs e)
    {
        //--- Show contents of help file.
        Help.ShowHelp(this, helpProviderMain.HelpNamespace);
    }
    private void mnuHelpIndex_Click(object sender, EventArgs e)
    {
        //--- Show index of help file.
        Help.ShowHelpIndex(this, helpProviderMain.HelpNamespace);
    }
    private void mnuHelpSearch_Click(object sender, EventArgs e)
    {
        //--- Show search tab of help file.
        Help.ShowHelp(this, helpProviderMain.HelpNamespace, HelpNavigator.Find);
    }
    private void mnuHelpTest_Click(object sender, EventArgs e)
    {
        //--- Show a web site with help content.
        Help.ShowHelp(this, "http://www.stackoverflow.com");
    }
    private void mnuHelpOpenTopicByName_Click(object sender, EventArgs e)
    {
        //--- Open topic by name.
        Help.ShowHelp(this, helpProviderMain.HelpNamespace, HelpNavigator.Topic, "Garden/tree.htm");
    }
    private void mnuHelpOpenTopicById_Click(object sender, EventArgs e)
    {
        //--- Open topic by ID.
        Help.ShowHelp(this, helpProviderMain.HelpNamespace, HelpNavigator.TopicId, "20010");
    }
    #endregion -----------------------------------------------
