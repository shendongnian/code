    if (upddate.ToString() == "")
    {
        dt = Convert.ToDateTime("01-01-1900", enGB);
    }
    else
    {
        dt = Convert.ToDateTime(date, enGB);
    }
    //when you go to the params, set dt for upddate instead of your string.
    SqlParameter[] param =
    {
        new SqlParameter("@id",id),
        new SqlParameter("@upddate",dt),
        ....
    }
