    DataSet dsXml = new DataSet();
    dsXml.ReadXmlSchema(Server.MapPath("~/Temp") + "//" + FileName);
    dsXml.ReadXml(Server.MapPath("~/Temp") + "//" + FileName, XmlReadMode.InferTypedSchema);
     if (!string.IsNullOrEmpty(dsXml.GetXml()))
    {
      for (int i = 0; i < dsXml.Tables.Count; i++)
                {
    lblInfo.Text = lblInfo.Text + dsXml.Tables["item"].Rows[i]["jid"].ToString()
               }
    }
