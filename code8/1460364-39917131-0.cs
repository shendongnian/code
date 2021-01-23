     public class Test
        {
            public string Seed { get; set; }
        }
    protected void Page_Load(object sender, EventArgs e)
		{
		   List<Test> test = new List<Test>();
            test.Add(new Test() {Seed = "ssss"});
            test.Add(new Test() { Seed = "aaaa" });
		    DGridView.DataSource = test;
            DGridView.DataBind();
		}
 
      protected void DGridView_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TextBox txtseed = new TextBox();
                    txtseed.ID = "txtseed";
                    txtseed.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "seed"));
                    e.Row.Cells[0].Controls.Add(txtseed);
                }
    
            }
     protected void Button1_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < DGridView.Rows.Count; i++)
            {
                var strDNo = DGridView.Rows[i].Cells[0].Text;
                TextBox dty =(TextBox)DGridView.Rows[i].Cells[0].FindControl("txtseed");
                var z = dty.Text;
            }
        }
