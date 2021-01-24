    protected void repFullSchedule_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater repCurrentShift = (Repeater)(e.Item.FindControl("repCurrentShifts"));
            string Start_time = DataBinder.Eval(e.Item.DataItem, "Start_Time").ToString();
            //DateTime my_Time = DateTime.ParseExact(Start_time, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            SqlCommand cmd = new SqlCommand("Select Job_Type FROM Shift WHERE Start_Time=@my_Time", con);
            cmd.Parameters.AddWithValue("@my_Time", Start_time);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            repCurrentShift.DataSource = dt;
            repCurrentShift.DataBind();
        }
    }
}
