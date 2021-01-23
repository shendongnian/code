    if (!IsPostBack)
        {
             Session["ExpInfo"] = string.Empty;
              string value = Session["ExpInfo"] as string;
             if (String.IsNullOrEmpty(value))
             {
               BindDataTable();
            }
            else
            {
                 dtExpInfo = (DataTable)Session["ExpInfo"];
                 if (strMode == "M")
                 {
                FunFillGridDetails();
                dtExpInfo = (DataTable)Session["ExpInfo"];
                }
           }
        }
   
    
    
