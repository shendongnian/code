      protected override void OnSelectedIndexChanged(EventArgs e)
      {
                base.OnSelectedIndexChanged(e);
           
         string desired_display = string.Empty;
         DataRowView r = (DataRowView)this.SelectedItem;
    
         if (r!=null)
         {
          desired_display = r["SURNAME"].ToString() + " " + r["NAME"].ToString();
         }
         BeginInvoke(new Action(() => this.Text = desired_display));
       }
