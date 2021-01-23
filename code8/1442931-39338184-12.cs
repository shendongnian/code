    if (!Page.IsPostBack)
        {
            txtId1.Attributes.Add("onblur", "javascript:CallMe('" + txtId1.ClientID + "', '" + txtContact1.ClientID + "')");
            txtId2.Attributes.Add("onblur", "javascript:CallMe('" + txtId2.ClientID + "', '" + txtContact2.ClientID + "')");
        }
