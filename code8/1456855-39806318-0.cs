     using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                {
                    oda.Fill(dtExcelData);
                  if(dtExcelData.rows.count<0)
                   {
                   for(int i=0;i<dtExcelData.rows.count;i++)
                    {
                      string mobno=dtExcelData.rows[i]["Mobile No#"].tostring();
                        if(mobno=="")
                         {
                           //code here 
                             }
                      }
                    }
    
                }
