        // xp.ExecuteNonQuery();  //this is unnecessary
        // the sql query will get executed by the da.Fill command.
        da = new SqlDataAdapter();
        da.SelectCommand = xp;
        da.Fill(ss);
        Showdata(pos);
        if ((int)ss.AsEnumerable().First()["Design"] == 1)
        {
            this.chkDesign.Checked = false;
        }
        else
        {
            this.chkDesign.Checked = true;
        }
