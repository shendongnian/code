        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
               Lable lblstus = e.Row.FindControl("lblstus") as Lable;
              Button btn_Out = e.Row.FindControl("btn_Out") as Button;
            Button btn_In = e.Row.FindControl("btn_In") as Button;
               if(lblstus.Text == "1")
                {
    btn_In.Visible = false;
                btn_Out.Visible = true;
            } else {
                btn_In.Visible = false;
                btn_Out.Visible = true;
            }
        }
        }
