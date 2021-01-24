        <asp:BoundField DataField="thumbNailUrl" HeaderText="Image" />
        
        protected void OnRowDataBound(object sender, EventArgs e)
        {
             var ea = e as GridViewRowEventArgs;
             if (ea.Row.RowType == DataControlRowType.DataRow)
             {
                 var d = ea.Row.DataItem as DataRowView;
                 var ob = d["thumbNailUrl"];
                 if (!Convert.IsDBNull(ob))
                 {
                     var cell = ea.Row.Cells[x];
                     cell.Text = String.Format("https://media.expedia.com{0}", ob.ToString());
                     
                 }
             }
         }
        	
