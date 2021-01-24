    if (myReader3.HasRows)
    {
         DataTable dt = new DataTable();
         dt.Load(myReader3);
    
         for (int i = 0; i < dt.Rows.Count; i++)
         {
             if (!DBNull.Value.Equals(dt.Rows[i]["childID"]))
             {
                 if (i == 0)
                 {
                     label1.Text = dt.Rows[i]["childID"].ToString();
                     label2.Text = "$" + Convert.ToDecimal(dt.Rows[i]["childNetWorth"]).ToString("N2");
                     label3.Text = dt.Rows[i]["childName"].ToString();
                 }
                 else if (i == 1)
                 {
                     label5.Text = dt.Rows[i]["childID"].ToString();
                     label6.Text = "$" + Convert.ToDecimal(dt.Rows[i]["childNetWorth"]).ToString("N2");
                     label7.Text = dt.Rows[i]["childName"].ToString();
                 }
                 else if (i == 2)
                 {
                     label9.Text = dt.Rows[i]["childID"].ToString();
                     label10.Text = "$" + Convert.ToDecimal(dt.Rows[i]["childNetWorth"]).ToString("N2");
                     label11.Text = dt.Rows[i]["childName"].ToString();
                 }
             }
             else
             {
                 if (i == 0)
                 {
                     label1.Text = "-ID-";
                     label2.Text = "-";
                     label3.Text = "-";
                 }
                 else if (i == 1)
                 {
                     label5.Text = "-ID-";
                     label6.Text = "-";
                     label7.Text = "-";
                 }
                 else if (i == 2)
                 {
                     label9.Text = "-ID-";
                     label10.Text = "-";
                     label11.Text = "-";
                 }
             }
         }
    }
