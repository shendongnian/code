    public partial class bVoteAnswer : System.Web.UI.Page
    {
        UserVotes ue = new UserVotes();
        bVotes bv = new bVotes();
        bVoteAnswers ve = new bVoteAnswers();
        public void Page_Load(object sender, EventArgs e)
        {
    
            dropdownlist.Enabled = false;
            int BuildingId = Convert.ToInt32(Session["BuildingId"]);
            DataTable dt = new DataTable();
            dt = bv.Select(0, "", "", "", BuildingId, "",0);
            Grid_Vote.DataSource = dt;
            Grid_Vote.DataBind();
    
        }
        protected void Grid_Vote_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
    
        protected void Grid_Vote_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropdownlist.Enabled = true;
            int VoteId = Convert.ToInt32(Grid_Vote.SelectedRow.Cells[0].Text);
            DataTable dt = new DataTable();
            dt = ve.Select(0,VoteId,"");
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                ListItem l = new ListItem(dt.Rows[i][2].ToString(), dt.Rows[i][2].ToString());
                dropdownlist.Items.Add(l);
            }
        }
    
        protected void btn_insert_Click(object sender, EventArgs e)
        {
            int OwnerId = Convert.ToInt32(Session["OwnerId"]);
            int VoteId = Convert.ToInt32(Grid_Vote.SelectedRow.Cells[0].Text);
            DataTable dt = new DataTable();
            dt = ve.Select(0, VoteId, dropdownlist.SelectedValue);
            int AnswerId = Convert.ToInt32(dt.Rows[0][0]);
            DateTime ClientDateTime = DateTime.Now;
            string PersianDate = GetPersianDate(ClientDateTime);
            ue.Insert(0, VoteId, OwnerId, AnswerId, PersianDate);
        }
    }
    
    public static class PersionCalendarExtension
    {
        public static string GetPersianDate(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            return string.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date));
        }
    }
