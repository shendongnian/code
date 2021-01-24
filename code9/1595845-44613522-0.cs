    Session["selected"] = "apple";
    Session["current"] = 1;
    
    string mycategory = Session["selected"].ToString();
    int myId = Convert.ToInt32(Session["current"]);
    int ra; //                                 ra = Rows Affected
    try {
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO [Marking] VALUES (@photoid, @photocategoryjudge, @totalmarks)", con);
        cmd.Parameters.Add("@photoid", SqlDbType.Int).Value = myId;
        cmd.Parameters.Add("@photocategoryjudge", SqlDbType.VarChar).Value = mycategory;
        cmd.Parameters.Add("@totalmarks", SqlDbType.Int).Value = totalMarks;
        ra = cmd.ExecuteNonQuery();
    }
    catch (SqlException sx) {
        ra = -2; //                             breakpoint here
        // If you stop here, your SQL has an error. Hover on sx for detail
        // Error handling routine
    catch (Exception ex) {
        ra = -1; //                             breakpoint here
        // non-sql error block. Hover on ex for more info
        // Error handling routine
    }
    finally {
        con.Close();
    }
    int Results = ra; //                        breakpoint here
