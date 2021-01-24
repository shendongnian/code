    var res = data.GroupBy(x => new { x.StaffName, x.ProjectName })
        .Select(x => new
        {
            StaffName = x.Key.StaffName,
            ProjectName = x.Key.ProjectName,
            Jan = x.Where(y => y.Month == "January").Sum(y => y.Weeks),
            Feb = x.Where(y => y.Month == "February").Sum(y => y.Weeks),
            Mar = x.Where(y => y.Month == "March").Sum(y => y.Weeks),
            Dec = x.Where(y => y.Month == "December").Sum(y => y.Weeks),
            //Add more month here
            Total = x.Sum(y => y.Weeks)
        });
