    private void GetCityAndTownSelectively()
    {
        if (Session["userid"] != null)
        {
            DataRow dr = function.GetDataRow("SELECT tbl_City.cityno, tbl_City.cityname, tbl_Town.townno, tbl_Town.townname FROM tbl_User LEFT JOIN tbl_City on tbl_City.cityno = tbl_User.city LEFT JOIN tbl_Town on tbl_Town.townno = tbl_User.town WHERE userid=" + Session["userid"].ToString());
            if (dr == null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                DrpDwnLstCity.Items.FindByValue(dr["cityno"].ToString()).Selected = true;
                DrpDwnLstTown.Items.FindByValue(dr["townno"].ToString()).Selected = true;
            }
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }
