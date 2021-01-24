    private void XmlToDataset() 
    {
        DataSet dsysStatTemp = new DataSet();
        XmlDocument doc = new XmlDocument();
        string xmlString = @"<dtSysStat>
         <ST> 2017 - 11 - 28T21: 14:58 + 03:00 </ST>
         <INST_ID> 1 </INST_ID>
         <RM> 1.34 </RM>
         <WM> 0.04 </WM>
         <RR> 86 </RR>
         <WR> 2 </WR>
         <TR> 0 </TR>
         </dtSysStat>";
    
        doc.Load(new StringReader(xmlString));
    
        XmlTextReader xtr = new XmlTextReader(doc.OuterXml, XmlNodeType.Element, null);
        dsysStatTemp.ReadXml(xtr);
        MessageBox.Show(dsysStatTemp.Tables[0].Rows[0]["ST"].ToString());
    }
