    grdCurrentMissions.DataSource = currentMissions.Select(o => new
            {
                column1 = o.ScheduledTime == DateTime.MinValue ? "-" : o.ScheduledTime.ToString(@"hh\:mm\:ss"),
                column1 = o.DepartureTime == DateTime.MinValue ? "-" : o.DepartureTime.ToString(@"hh\:mm\:ss"),
            }).ToList();
