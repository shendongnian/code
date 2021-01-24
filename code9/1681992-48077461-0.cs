    var upcomingMeetings = meetings.Where(e => e.StartDate > DateTime.Now);
    var passedMeetings = meetings.Where(e => e.StartDate <= DateTime.Now);
    return View(HomeIndex, new HomePageModel()
    {
        UpcommingMeetings = upcomingMeetings,
        PassedMeetings = passedMeetings
    });
