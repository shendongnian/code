    public class User
    {
        public User()
        {
            UserSkills = new Dictionary<string, UserSkill>();
        }
        public string Name { get; set; }
        public Dictionary<string, UserSkill> UserSkills { get; set; }
        public List<string> UniqueSkills
        {
            get { return UserSkills.Values.Select(x => x.Skill).Distinct().ToList(); }
        }
    }
    public class Users : List<User>
    {
        public List<string> UniqueSkills
        {
            get
            {
                var retVal = new List<string>();
                foreach (var user in this)
                {
                    retVal.AddRange(user.UniqueSkills);
                }
                return retVal.Distinct().OrderByDescending(x => x).ToList();
            }
        }
        public int ColSpan => (UniqueSkills.Count * 2);
    }
