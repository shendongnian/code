    private bool RenameTestCase(string oldValue, string newValue, string selectedNodeUID)
    {
        if (selectedNodeUID == null) throw new ArgumentException("selectedNodeUID", "is null");
        if (newValue == null) throw new ArgumentException("newValue", "is null");
        
        bool IsSuccess = false;
        // check with Xpath
        // if the any nodes named TestCase : //TestCase[]
        // where its UID attribute isn't equal: not(@UID='{0}')
        // and the name attribute equals our newvalue: @name='{1}'
        var nodeExist = xmlDocument.SelectSingleNode(
            String.Format("//TestCase[not(@UID='{0}') and @name='{1}']", 
              selectedNodeUID,
              newValue));
        if (nodeExist != null) 
        {
            MessageBox.Show(newValue + " is already exists.");
            IsSuccess = false;
        } 
        else 
        {
            // find the node to update
            // any TestCase node: //TestCase[]
            // where the UID attribute equals the selectedUid: @UID='{0}'
            var node = xmlDocument.SelectSingleNode(
                String.Format("//TestCase[@UID='{0}']", selectedNodeUID)); 
            if (node == null) 
            {
               // error
               MessageBox.Show(selectedNodeUID + " UID not found");
               IsSuccess = false;
            } 
            else
            {
               // set the new value
               node.Attributes[CommonDef.NameTag].Value = newValue;
               IsSuccess = true;
            }
        }
        
        xmlDocument.Save(Path.Combine(l_csConfigFolderPath, CommonDef.TESTSUITE_DATA));
    
        // don't forget to return something
        return IsSuccess;
    }
