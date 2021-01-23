     DataTable checkedData = new DataTable();
        checkedData.Columns.AddRange(new DataColumn[6] { new DataColumn("CampCode"), new DataColumn("BalUnits", typeof(decimal)), new DataColumn("ExitUni",typeof(decimal)), new DataColumn("itemNum"), new DataColumn("UOM"), new DataColumn("WT", typeof(decimal)) });
        foreach (RepeaterItem item in rptItems.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox checkBoxInRepeater = item.FindControl("cbItem") as CheckBox;
                if (checkBoxInRepeater.Checked)
                {
                    DataRow dr = checkedData.NewRow();
                    Label lblCampCode = (Label)item.FindControl("lblCampCode");
                    Label lblBalUnits = (Label)item.FindControl("lblBalUnits");
                    TextBox txtExitUnits = (TextBox)item.FindControl("txtExitUnits");
                    Label lblItemNo = (Label)item.FindControl("lblItemNo");
                    Label lblUom = (Label)item.FindControl("lblUom");
                    Label lblWT =  (Label)item.FindControl("lblWt");
                    Label lblcode = (Label)item.FindControl("lblCode");
                    HiddenField hfcode = (HiddenField)item.FindControl("hfCustomerId");
                    string BalUnits = lblBalUnits.Text;
                    string ExitUni = txtExitUnits.Text;
                    
                    var exitUni = decimal.Parse(txtExitUnits.Text);
                    var balUni = decimal.Parse(BalUnits);
                    if (exitUni > balUni)
                    {
                      string myStringVariable = "Exit balance is larger than balance units!!";
                      ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                    }
                    else
                    { 
                        dr["CampCode"] = lblCampCode.Text;
                        dr["BalUnits"] = lblBalUnits.Text;
                        dr["itemNum"] =  lblItemNo.Text;
                        dr["UOM"] = lblUom.Text;
                        dr["WT"] = lblWT.Text;
                        dr["ExitUni"] = txtExitUnits.Text.Trim();
                        //string code = hfcode.Value;
                        checkedData.Rows.Add(dr);
                        Session["CheckedRows"] = checkedData;
