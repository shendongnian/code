     DataTable dtx = GetAmens(Id);
     string strAmen = "";
     if (dtx.Rows.Count > 0)
     {
         strAmen += @"<ul class='col-md-6'>";
         int c = 0;
        
         foreach (DataRow dr in dtx.Rows)
         {
             if (c >= ((dtx.Rows.Count / 2) + (dtx.Rows.Count % 2)))
             {
                 strAmen += @"</ul><ul class='col-md-6'>";
                 for (c=c; c < dtx.Rows.Count; c++)
                 {
                      strAmen += "<li class='enabled'>" + dtx.Rows[c]["amen"].ToString() + "</li>";
                 }
                 strAmen += @"</ul>";
                 break;
             }
             strAmen += "<li class='enabled'>" + dr["amen"].ToString() + "</li>";
             c++;
         }
     }
