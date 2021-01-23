        if (Chbk_NewProject.Checked && Chbk_Resale.Checked )
         {
           Response.Redirect("PropertiedDetailsByTypeList.aspx?id1=1&id1=2&text=" + HF_SEARCH.Value);
                                                             ---^  ---^
         }
    
    Then Request.Querystring("id1") will return 1,2
    
    This can then be put into an ArrayList like Request.Querystring("ProductID").split(",")
