    private List<AthleteVideoViewModel> PopulateVideosWithAthleteID(int anAthleteId)
    {
        using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString("acgvideodbConnectionString")))
        {
            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    List<AthleteVideoViewModel> vidmod = new List<AthleteVideoViewModel>();
                    cmd.CommandText = "SELECT Athlete_Name.AthleteID AS AthleteID, Athlete_Video.anAthleteID AS anAthleteID, Athlete_Video.AthleteVideo AS AthleteVideo FROM Athlete_Video INNER JOIN Athlete_Name ON Athlete_Name.AthleteID = Athlete_Video.anAthleteID WHERE Athlete_Video.anAthleteID = @anAthleteId";
                    cmd.Parameters.Add(new SqlParameter("@anAthleteId", anAthleteId);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                    vidmod = ds.Tables[0].AsEnumerable().Select(dataRow => new AthleteVideoViewModel { AthleteID = dataRow.Field<int>("AthleteID"), anAthleteID = dataRow.Field<int>("anAthleteID"), AthleteVideo = dataRow.Field<string>("AthleteVideo") }).ToList();
                    return vidmod;
                }
                finally
                {
                }
            }
        }
    }
