    DataRow[] result = dsDocColor.Select("Initials = '"+row.Cells["Primary_Onc"].Value.ToString()+"'");
                
                string DocColor = result[0][2].ToString();
                
                row.Cells["Last_Name"].Style.BackColor = System.Drawing.Color.FromName(DocColor);
                 
                row.Cells["First_Name"].Style.BackColor = System.Drawing.Color.FromName(DocColor);
                row.Cells["Primary_Onc"].Style.BackColor = System.Drawing.Color.FromName(DocColor);
               
