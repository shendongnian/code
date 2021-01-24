    `protected void grdMessages_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                LinkButton btnXML = (LinkButton)item["DownloadXml"].Controls[0];
                btnXML.Click += new EventHandler(btnXML_Click);
                btnXML.Attributes.Add("OnClick", "DownloadXML(); return false;");
            }
        }
    `
