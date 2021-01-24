        protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
            Button btnDelete = (Button)e.Row.FindControl("btnDelete");
            CheckBox CHKID= (CheckBox)e.Row.FindControl("CHKID");
               
         if(CHKID.Checked == true)
         {
           if(CHKID.Text !="")
           {
             int id = Convert.ToInt32(CHKID.Text);
             //Pass this ID to DB and Delete record.
           }
         }
        
        }
      }
