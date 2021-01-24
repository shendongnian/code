        Label lblInfo = (Label)gvVisa_Mofa.Rows[i].FindControl("lblInfo");
        if (lblInfo.Text <= "0")
        {
            gvVisa_Mofa.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#EDA3A3");
          
        }
    
