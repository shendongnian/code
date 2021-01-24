    public string getHtmlData()
        {
            SAPConnClass cfg = new SAPConnClass();
            RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
            // **check RegisterDestination**
            if (dest == null)
            {
                RfcDestinationManager.RegisterDestinationConfiguration(cfg);
            }
            RfcRepository repo = dest.Repository;
            IRfcFunction func = repo.CreateFunction("ZMM_AGING_STOCK");
            // **below are its respective import/input parameters to the RFC Function**
            func.SetValue("T_WERKS", "X123");
            func.SetValue("T_BUDAT", System.DateTime.Now);
            func.SetValue("T_SPMON", "201708");
            func.Invoke(dest);
            IRfcTable tblFunc = func.GetTable("OUTPUT");
            string strHtml = "";
            // **loop through the rows to process the record**
            for (int i = 0; i < tblFunc.Count; i++)
            {
                strHtml += "<tr>";
                strHtml += "<td>" + tblFunc[i].GetValue("MATNR").ToString() + "</td>";
                strHtml += "<td>" + tblFunc[i].GetValue("CLOSE_MENGE").ToString() + "</td>";
                strHtml += "</tr>";
            }
            return strHtml;
        }
