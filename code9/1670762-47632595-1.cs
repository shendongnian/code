      void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          for(var cell in e.Row.Cells)
          {
           int val = 0; 
           if(int.TryParse(cell.Text,out val)
           {
            //you can have hyper link here 
            if(val > 0)
            cell.Text = "<a href='void(0);'>" + cell.Text + "</a>";
           }
          } 
      
        }
      }
