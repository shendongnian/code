        HttpProxy proxy = new HttpProxy
                    {
                        Method = HttpMethod.POST,
                        Url = "../../../Handlers/BoneWL.ashx"
                    };
        
                            // Create Reader
                            Ext.Net.JsonReader reader = new Ext.Net.JsonReader
                            {
                                Root = "plants",
                                TotalProperty = "total",
                                Fields = {
                        new RecordField("ItemCode"),
                        new RecordField("ItemName"),
                        new RecordField("OnHand") 
                    }
                            };
        
                            // Add Proxy and Reader to Store
                            Store store = new Store
                            {
                                Proxy = { proxy },
                                Reader = { reader },
                                AutoLoad = false
                            };
        
                            // Create ComboBox
                            Ext.Net.ComboBox cmb = new Ext.Net.ComboBox
                            {
                                DisplayField = "ItemCode",
                                ValueField = "ItemCode",
                                TypeAhead = false,
                                LoadingText = "加载中...",
                                Width = 240,
                                PageSize = 10,
                                HideTrigger = true,
                                ItemSelector = "tr.list-item",
                                MinChars = 1,
                                Store = { store }
                            };
                            
                            cmb.Listeners.TriggerClick.Handler = "UseDirectEvents('1');WinRowCancelEdit();";
                            cmb.Triggers.Add(new FieldTrigger() { Icon = TriggerIcon.Search });
                            cmb.TriggerIcon = TriggerIcon.Search;
                            StringBuilder sHtml = new StringBuilder();
                            sHtml.Append(" <tpl for=\".\"><tpl if=\"[xindex] == 1\">");
                            sHtml.Append("<table class=\"cbStates-list\" ><tr>");
                            sHtml.Append("<th style=\"color: #2f353b !important;\">ItemCode</th>");
                            sHtml.Append(" <th style=\"color: #2f353b !important;\">ItemName</th>");
                            sHtml.Append("<th style=\"color: #2f353b !important;\">OnHand</th>");
                            sHtml.Append("</tr> </tpl>");
                            sHtml.Append("<tr class=\"list-item\">");
                            sHtml.Append("<td style=\"padding:3px 0px;\">{ItemCode}</td>");
                            sHtml.Append("<td>{ItemName}</td>");
                            sHtml.Append("<td>{OnHand}</td>");
                            sHtml.Append("</tr> <tpl if=\"[xcount-xindex]==0\">");
                            sHtml.Append(" </table> </tpl> </tpl>");
                            cmb.Template.Html = sHtml.ToString();
    Panel1.Items.Add(cmb);
