      try
      {
         string strQueryGetValue = "select columnname from tablename where id = '1'";
         string strValue = GetValueFromDBUsing(strQueryGetValue );
         if(strValue.length > 0)
         {
               MessageBox.Show("Found");
              MessageBox.Show(strValue);
         }
         
         else
             MessageBox.Show("Not Found");         
      }
      catch(Exception ex)
      {
          MessageBox.Show(ex.Message.ToString()); 
      }
