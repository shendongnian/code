    private List<Clockings> clockingTime(string Branch, DateTime StartDate, DateTime Enddate, string Name, String Department, string ReportType)
        {
            List<Clockings> f = new List<Clockings>();
            List<DailyClocking> d2 = new List<DailyClocking>();
            string  UserName = "", StartTime = "", BranchFromSP = "", DepartmentFromSP = ""; 
            int NoofDaysClocked = 0;
            float noofusers = 1;
            int tmpemp = 0;
            int col = 0;
            var cmd = db.Database.Connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (ReportType == "ALLDOORS")
            {
            }
            else
            {
                cmd.CommandText = "[dbo].LateClocking";
            }
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@StartDate";
            param.Value = StartDate.ToString("yyyyMMdd");
            cmd.Parameters.Add(param);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@EndDate";
            param1.Value = Enddate.ToString("yyyyMMdd");
            cmd.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@Branch";
            param2.Value = Branch;
            cmd.Parameters.Add(param2);
            if (Department.ToUpper()  == "NONE")
            {
                Department = "";
            }
            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@department";
            param3.Value = Department;
            cmd.Parameters.Add(param3);
            if (Name.ToUpper()  == "ALL")
            {
                Name = "";
            }
            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@Nme";
            param4.Value = Name;
            cmd.Parameters.Add(param4);
            try
            {
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (tmpemp == int.Parse(reader["mst_sq"].ToString()))
                        { }
                        else
                        {
                            if (noofusers > 1)
                            {
                                f.Add(new Clockings(
                                    BranchFromSP, 
                                    DepartmentFromSP,
                                    UserName,
                                    StartTime,
                                    NoofDaysClocked,
                                    d2
                                    ));
                            }
                            col = 0;
                            noofusers = noofusers + 1;
                            tmpemp = int.Parse(reader["mst_sq"].ToString());
                            UserName = reader["mst_firstname"].ToString() + " " + reader["mst_lastname"].ToString();
                            StartTime = reader["starttime"].ToString();
                            DepartmentFromSP = reader["dept_name"].ToString();
                            BranchFromSP = reader["branch"].ToString();
                            d2.Clear();
                        }
                        if (reader["dy"].Equals(System.DBNull.Value))
                        { }
                        else
                        {
                            d2.Add(new DailyClocking
                            (
                                reader["dy"].ToString().Substring(0, 4) + reader["dy"].ToString().Substring(5, 2) + reader["dy"].ToString().Substring(8, 2),
                                reader["dy"].ToString(),
                                reader["mnearly"].ToString(),
                                reader["mnlate"].ToString(),
                                reader["tmeclocked"].ToString().Substring(11, 5),
                                reader["earlyclocked"].ToString().Substring(11, 5)
                            ));
                        }
                        col = col + 1;
                        NoofDaysClocked = col;
                       
                    }
                    f.Add(new Clockings(
                         BranchFromSP,
                                    DepartmentFromSP,
                        UserName,
                        StartTime,
                        NoofDaysClocked,
                        d2
                        ));
                }
            }
            catch (Exception ex)
            {
                // your handling code here
                ex = ex;
            }
         
            return (f);
        
    <html>
    <head>
    <meta name="viewport" content="width=device-width" />
    <title>Clocking Report</title>
    </head>
    <body>
    <span style="font-size:small;float:right">@Html.ActionLink("Back", "ClockingParamaters", "ManagerSection")</span>
    <div style="width: 100%; height: 500px; overflow: auto;">
        <table class="table" ; style="width:@(MostDaysClock+"px");">
            <thead>
                <tr>
                    <th style="width:70px; height:100px;padding-top:80px;">
                        Branch
                    </th>
                    <th style="width:150px; height:100px; padding-top:80px;">
                        Department
                    </th>
                    <th style="width:175px; height:100px; padding-top:80px;">
                        Name
                    </th>
                    <th style="width:100px; height:100px; padding-top:80px;">
                        Start Time
                    </th>
                    @{
                        DateTime StartDate = ViewBag.StartDate;
                        DateTime EndDate = ViewBag.EndDate;
                        for (DateTime date = StartDate; date.Date <= EndDate.Date; date = date.AddDays(1))
                        {
                            ColumnHeader[ColumnCount] = date.ToString("yyyyMMdd");
                            ColumnCount++;
                            <th class="rotate" ; style="width: 100px;">
                                <div>
                                    <span>
                                        @Html.DisplayFormattedData(date.ToString("yyyy/MM/dd"))
                                    </span>
                                </div>
                            </th>
                         
                        }
                        TotalColumnCount = ColumnCount;
                    }
                </tr>
            <tbody style="height: 100%; ">
                @foreach (var ClockingDisplay in Model)
                {
                    ColumnCount = 0;
                    StaffClockingCount = 0;
                    <tr style="height:40px;">
                        <td style="width:70px;"> @Html.DisplayFor(modelItem => ClockingDisplay.Branch )</td>
                        <td style="width:150px;white-space:nowrap; text-overflow: ellipsis;overflow:hidden"> @Html.DisplayFor(modelItem => ClockingDisplay.Department)</td>
                        <td style="width:175px;"> @Html.DisplayFor(modelItem => ClockingDisplay.UserName)</td>
                        <td style="width:125px;"> @Html.DisplayFor(modelItem => ClockingDisplay.StartTime)</td>
                        @do
                        {
                            if (ClockingDisplay.DailyClockings.Count   > 0)
                            {
                                if (ClockingDisplay.DailyClockings[StaffClockingCount].ClockingDate == ColumnHeader[ColumnCount])
                                {
                                    if (Convert.ToInt32(ClockingDisplay.DailyClockings[StaffClockingCount].MinOutEarly) < 0)
                                    {
                                        Double vl = Convert.ToInt32(ClockingDisplay.DailyClockings[StaffClockingCount].MinOutEarly) * -1;
                                     <td style="width:50px;height:40px;border:solid;border-width:1px;text-align:center; background-color:red;font-size:small  ">@Html.DisplayFormattedData(vl.ToString())</td>
                                    }
                                    else if (Convert.ToInt32(ClockingDisplay.DailyClockings[StaffClockingCount].MinOutEarly) == 0)
                                    {
                                    <td style="width:50px;height:40px;border:solid;border-width:1px;text-align:center; font-size:small  ">@Html.DisplayFormattedData(ClockingDisplay.DailyClockings[StaffClockingCount].MinOutEarly)</td>
                                    }
                                    else
                                    {
                                    <td style="width:50px;height:40px;border:solid;border-width:1px;text-align:center; background-color:green;font-size:small   ">@Html.DisplayFormattedData(ClockingDisplay.DailyClockings[StaffClockingCount].MinOutEarly)</td>
                                    }
                                    if (Convert.ToInt32(ClockingDisplay.DailyClockings[StaffClockingCount].MinInEarly) < 0)
                                    {
                                        Double vl = Convert.ToInt32(ClockingDisplay.DailyClockings[StaffClockingCount].MinInEarly) * -1;
                                    <td style="width:50px;height:40px;border:solid;border-width:1px;text-align:center;background-color:green; font-size:small  ">@Html.DisplayFormattedData(vl.ToString())</td>
                                    }
                                    else if (Convert.ToDouble(ClockingDisplay.DailyClockings[StaffClockingCount].MinInEarly) == 0)
                                    {
                                    <td style="width:50px;height:40px;border:solid;border-width:1px;text-align:center;font-size:small"> @Html.DisplayFormattedData(ClockingDisplay.DailyClockings[StaffClockingCount].MinInEarly)</td>
                                    }
                                    else
                                    {
                                    <td style="width:50px;height:40px;border:solid;border-width:1px;text-align:center;background-color:red; font-size:small  "> @Html.DisplayFormattedData(ClockingDisplay.DailyClockings[StaffClockingCount].MinInEarly)</td>
                                    }
                                    StaffClockingCount++;
                                    if (StaffClockingCount > ClockingDisplay.DailyClockings.Count - 1)
                                    {
                                        StaffClockingCount = ClockingDisplay.DailyClockings.Count - 1;
                                    }
                                }
                                else
                                {
                                    <td style="width:50px;height:40px;border:solid;border-width:1px;background-color:blue;"></td>
                                    <td style="width:50px;height:40px;border:solid;border-width:1px;background-color:blue;"></td>
                                }
                            }
                            else
                            {
                                <td style="width:50px;height:40px;border:solid;border-width:1px;background-color:blue;"></td>
                                <td style="width:50px;height:40px;border:solid;border-width:1px;background-color:blue;"></td>
                            }
                            ColumnCount++;
                        } while (ColumnCount < TotalColumnCount);
                    </tr>
                }
            </tbody>
        </table>
    </div>
