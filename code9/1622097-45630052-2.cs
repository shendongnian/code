    private bool RenameTestCaseXdoc(string oldValue, string newValue, string selectedNodeUID)
    {
        if (selectedNodeUID == null) throw new ArgumentException("selectedNodeUID", "is null");
        if (newValue == null) throw new ArgumentException("newValue", "is null");
        
        var xdoc = XDocument.Load(Path.Combine(l_csConfigFolderPath, CommonDef.TESTSUITE_DATA));
        
        var exist = xdoc.Descendants("TestCase")
            .Where(elem => elem.Attribute("UID").Value != selectedNodeUID 
                        && elem.Attribute("name").Value == newValue)
            .Any();
        if (exist) 
        {
           MessageBox.Show(newValue + " is already exists.");
          return false;
        } 
        else
        {
           var element = xdoc.Descendants("TestCase")
                         .Where(elem => elem.Attribute("UID").Value == selectedNodeUID)
                         .SingleOrDefault();
            if (element == null) 
            {
                MessageBox.Show(selectedNodeUID + " not found.");
                return false;
            }
            else
            {
                element.Attribute("name").Value = newValue;
            }
        }
        xdoc.Save(Path.Combine(l_csConfigFolderPath, CommonDef.TESTSUITE_DATA));
        return true;
    }
