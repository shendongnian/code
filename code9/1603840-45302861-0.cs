    System.Collection.Generic.List<System.Collection.Generic.KeyValuePair<string, bool>> MyList = new System.Collection.Generic.List<System.Collection.Generic.KeyValuePair<string, bool>>();
    string NodeText = string.Empty;
    bool = TextExist = false;
    SAPFEWSELib.GuiTree GT = (SAPFEWSELib.GuiTree)SAPWindow.FindById(ID);
    foreach(string key in GT.GetAllNodeKeys()){
         NodeText = GT.GetItemText(key, "1"); //1 is the column index, starts with 1
         if(GT.GetItemText(key, "2").Length > 0){TextExist = true;}else{TextExist = false;}
         MyList.Add(new System.Collection.Generic.KeyValuePair(NodeText, TextExist);   
    }
