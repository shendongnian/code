        // xp.ExecuteNonQuery();  //this is unnecessary
        // the sql query will get executed by the da.Fill command.
        da = new SqlDataAdapter();
        da.SelectCommand = xp;
        da.Fill(ss);
        Showdata(pos);
        if (ss.Rows.Count > 0) {
          this.chkDesign.Checked = ((int)ss.AsEnumerable().First()["Design"] == 1);
        }
