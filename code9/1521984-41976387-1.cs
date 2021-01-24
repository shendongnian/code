    protected void Page_PreRender(object sender, EventArgs e)
    {
            var nodes = _administrationSystem.GetNodes(); //The dataset with data
            var translators = _phonesSystem.GetPhoneNumberTranslators(); //The dataset with data
    
            if (rptList.Items.Count > 0)
            {
                for (var count = 0; count < rptList.Items.Count; count++)
                {
                    var ddlNodeEdit = (DropDownList)rptList.Items[count].FindControl("ddlNodeEdit");
                    var ddlTranslatorEdit = (DropDownList)rptList.Items[count].FindControl("ddlTranslatorEdit");
    
                    ddlNodeEdit.DataSource = nodes.Tables[0];
                    ddlNodeEdit.DataTextField = "NodeName";
                    ddlNodeEdit.DataValueField = "ID";
                    ddlNodeEdit.DataBind();
                    ddlNodeEdit.Items.Insert(0, new ListItem("TRNSLTChoose node", "0"));
    
                    ddlTranslatorEdit.DataSource = translators.Tables[0];
                    ddlTranslatorEdit.DataTextField = "Description";
                    ddlTranslatorEdit.DataValueField = "ID";
                    ddlTranslatorEdit.DataBind();
                    ddlTranslatorEdit.Items.Insert(0, new ListItem("TRNSLTChoose numbertranslator", "0"));
                }
            }
    }
