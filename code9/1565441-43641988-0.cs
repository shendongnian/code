     public string volunteers()
    {
        SqlCommand cmd = new SqlCommand(@"SELECT * FROM fundraiser_youth WHERE reportTime >='" + DateTime.Now + "' ORDER BY reportTime" , con);
        con.Open();
        SqlDataReader reader;
        try
        {
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DateTime reportTime = Convert.ToDateTime(reader["reportTime"]);
                    DateTime gateTime = Convert.ToDateTime(reader["gateTime"]);
                    DateTime gameTime = Convert.ToDateTime(reader["gameTime"]);
                    events.Append("<div class='col-md-4'>");
                    events.Append("<div class='well well-lg'>");
                    events.Append("<form action='register/default.aspx' method='POST'>");
                    events.Append("<h4>" + reportTime.DayOfWeek + " " + reportTime.Month + "/" + reportTime.Day + "/" + reportTime.Year + "</h4>");
                    events.Append("<h5>" + reader["eventName"].ToString() + " " + reader["location"].ToString() + " " + reportTime.ToString("h:mm tt", CultureInfo.InvariantCulture) + "</h5>");
                    events.Append(loadHelpers(reader["id"].ToString()));
                    events.Append("<!--<span style='text-align:right; margin-top:20px;'><input type='submit' value='Edit' class='btn btn-info' /></span>-->");
                    events.Append("</form>");
                    events.Append("</div>");
                    events.Append("</div>");
                }
                return events.ToString();
            }
            return "no info provided";
        }
        catch (Exception e)
        {
            return "ERROR" + e;
        }
    }
    public string loadHelpers(string id)
    {
        var cmd2 = new SqlCommand(@"SELECT * FROM fundrasier_helpers WHERE eventID='"+ id + "'" , con2);
        con2.Open();
        if (cmd2.ToString() != "")
        {
            SqlDataReader reader2;
            StringBuilder helper = new StringBuilder();
            helper.Append("<ul>");
            try
            {
                reader2 = cmd2.ExecuteReader();
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        helper.Append("<li>" + reader2["firstName"] + " " + reader2["lastName"] + " " + reader2["phone"] + " " + reader2["shirtSize"] + "</li>");
                    }
                }
                reader2.Close();
            }
            catch (Exception e)
            {
                helper.Append("<li>No volunteers have signed up " + e + "</li>");
            }
            helper.Append("</ul>");
            con2.Close();
            return helper.ToString();
        }
        else
        {
            return "<ul><li>No volunteers have signed up</li></ul>";
        }
    }
