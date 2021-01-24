    DateTime dob = Convert.ToDateTime(Request.Form["DOB"]);
    DateTime jd = Convert.ToDateTime(Request.Form["JD"]);
    ....
    using(MySqlConnection con = new MySqlConnection(constr))
    using(MySqlCommand com = new MySqlCommand("userDetails", con))
    {
        com.CommandType = CommandType.StoredProcedure;
        MySqlParameter p1 = new MySqlParameter("nickName", MySqlDbType.VarChar).Value = nickNameTB.Text;
        MySqlParameter p2 = new MySqlParameter("dob", MySqlDbType.Date).Value = dob;
        MySqlParameter p3 = new MySqlParameter("joinDt", MySqlDbType.Date).Value = jd;
        ....
        con.Open();
        com.ExecuteNonQuery();
    }
