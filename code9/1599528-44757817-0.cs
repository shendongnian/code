    using (Microsoft.SharePoint.SPSite site = new Microsoft.SharePoint.SPSite("http://soweto:5000/sites/SPDWF_Issue"))
                    {
                        using (Microsoft.SharePoint.SPWeb web = site.OpenWeb())
                        {
                   Microsoft.SharePoint.SPList list = web.Lists["Cust"];
        
                            Microsoft.SharePoint.SPListItem item = list.Items.Add();  
        
                   SPFieldMultiLineText multilineField = item.Fields.GetField("YourColumn") as SPFieldMultiLineText;
                   // Get the field value as HTML
                   string htmltext= multilineField.GetFieldValueAsHtml(item["YourColumn"], item);
        
                   //or Get the field as Text
                   string normaltext= multilineField.GetFieldValueAsText(item["YourColumn"]); 
        
                   //updating html field text
                   htmltext+= "Hello I am being updated!";
                   item["YourColumn"] = htmltext;
                   item.Update();
                 }
        }
