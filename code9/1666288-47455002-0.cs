    private void GetMax()
    {
        d = "select MAX(Req_ID) as ID from Request";
        d = lblReq.Text;
        DataTable dt = db.getTable(d);
        if (dt != null && dt.Rows.Count > 0)
        {
            R = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
        }
    }
