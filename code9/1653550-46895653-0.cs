    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var users = new Users();
            users.Add(CreateUser("Bob", 2, true, 3, false, 1, true));
            users.Add(CreateUser("Sue", 1, true, 1, true, 0, false));
            users.Add(CreateUser("Margaret", 1, true, 1, false, 2, true));
            return View(users);
        }
        private User CreateUser(string name,
                                int coffeeSkillLevel, bool coffeeInterested,
                                int typingSkillLevel, bool typingInterested,
                                int searchSkillLevel, bool searchInterested)
        {
            const string skillCoffee = "Coffee";
            const string skillTyping = "Typing";
            const string skillSearching = "Google Search";
            var user = new User() { Name = name };
            var userBobSkillCofeeMaking = new UserSkill
            {
                Skill = skillCoffee,
                SkillLevel = coffeeSkillLevel,
                IsInterested = coffeeInterested
            };
            var userBobSkillTyping = new UserSkill
            {
                Skill = skillTyping,
                SkillLevel = typingSkillLevel,
                IsInterested = typingInterested
            };
            var userBobSkillGoogleSearching = new UserSkill
            {
                Skill = skillSearching,
                SkillLevel = searchSkillLevel,
                IsInterested = searchInterested
            };
            user.UserSkills[skillCoffee] = userBobSkillCofeeMaking;
            user.UserSkills[skillTyping] = userBobSkillTyping;
            user.UserSkills[skillSearching] = userBobSkillGoogleSearching;
            return user;
        }
    }
