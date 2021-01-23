    [HttpGet]
    public ActionResult Index()
    {
        List<User> userList = new List<User>();
        for (int i = 1; i < 4; i++)
        {
            User objUser = new User();
            objUser.Id = i;
            objUser.Name = "Name" + i.ToString();
            userList.Add(objUser);
        }
        List<UserEducation> userEducationList = new List<UserEducation>();
        for (int i = 1; i < 4; i++)
        {
            UserEducation objUserEducation = new UserEducation();
            objUserEducation.Id = i;
            objUserEducation.Education = "Education" + i.ToString();
            objUserEducation.PassingYear = 2015+i;
            userEducationList.Add(objUserEducation);
        }
        return View(new Tuple<List<User>, List<UserEducation>>(userList, userEducationList));
    }
