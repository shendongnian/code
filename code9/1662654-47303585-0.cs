    SPContentType spctExampleContentType = list.ContentTypes["Example Content Type"];
    
    SPListItem item = list.Items.Add();
    item["ChangeReference"] = "1";
    item[SPBuiltInFieldId.Title] = title.Text;
    item["Title"] = title.Text;
    item["Risk"] = risk.Text;
    item["Probability"] = probability.Text;
    spliNewItem["ContentTypeId"] = spctExampleContentType.Id;
    item.Update();
