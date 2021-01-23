        static void Main(string[] args)
        {
            ApplicationUser a = new ApplicationUser();
            a.userName = "a";
            a.role = 1;
            ApplicationUser b = new ApplicationUser();
            b.userName = "b";
            b.role = 3;
            List<ApplicationUser> alist=new List<ApplicationUser>();
            alist.Add(a);
            alist.Add(b);
            Dictionary<int, string> DicRoles = new Dictionary<int, string>();
            var vals = Enum.GetValues(typeof(Roles));
            foreach (var val in vals)
            {
                DicRoles.Add((int)val, val.ToString());
            }
            var result = from t in alist
                         join x in DicRoles on t.role equals x.Key
                         select new {t.userName,x.Value };
        }
        public enum Roles:int
        {
            Administrator = 1,
            Headquarters = 2,
            Branch = 3,
            Driver = 4,
            Client = 5
        }
    }
    public class ApplicationUser
    {
        public string userName { get; set; }
        public int role { get; set; }
    }
