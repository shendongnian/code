        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
                //do stuff here
                DataTable dt = Session["lastRecord"] as DataTable;
                DataRow row = dt.NewRow();
                row["1"] = "A";
                row["2"] = "B";
                row["3"] = "C";
                row["4"] = "D";
                dt.Rows.Add(row);
                Session["lastRecord"] = dt;
                lastRecordTable();
        }
