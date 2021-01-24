    @{
        var variableName = HelperToTables.ContentText.ContentIdValue.GetInfoContentInfo.GetColBool(Model.HiddenId);
    } 
    @if(variableName == true)
    {
       // do your stuff
    }
    else if(variableName == false)
    {
        // do your stuff
    }
