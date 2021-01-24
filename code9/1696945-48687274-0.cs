    public class MeetingController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public static Meeting NewMeeting;
        public static List<DateTime> TempTimes = new List<DateTime>();
        public ActionResult CreateMeeting()
        {
           return View();
        }
    public ActionResult CreateAMeeting(Meeting meeting)
    {
        var userName = User.Identity.Name;
        var user = db.Users.FirstOrDefault(u => u.UserName == userName);
        var model = new MeetingPeopleViewModel();
        meeting.Creator = user;
        meeting.Invited.Add(user);
        meeting.Times = TempTimes;
        meeting.Start = DateTime.Now;
        meeting.End = meeting.Start.AddMinutes(meeting.Minutes);
        db.Meetings.Add(meeting);
        db.SaveChanges();
        return View("AddToMeeting", model);
    }
    public ActionResult AddTempTime(DateTime Start, Meeting meeting)
    {
        TempTimes.Add(Start);
        meeting.Times = TempTimes;
        return View("CreateMeeting", meeting);
    }
    public ActionResult ChooseTimes()
    {
        var userName = User.Identity.Name;
        var user = db.Users.FirstOrDefault(u => u.UserName == userName);
        Meeting meeting = new Meeting();
        List<Meeting> Meetings = db.Meetings.ToList();
        foreach (var item in Meetings)
        {
            if (item.Invited.Contains(user))
            {
                meeting = item;
            }
        }
        return View(meeting);
    }
