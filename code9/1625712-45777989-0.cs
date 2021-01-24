    class Program
    {
        static void Main(string[] args)
        {
            List<TeamNeeds> needs = new List<TeamNeeds>();
            
            TeamNeeds n1 = new TeamNeeds();
            n1.QB = "starter";
            TeamNeeds n2 = new TeamNeeds();
            n2.RB = "starter";
            needs.Add(n1);
            needs.Add(n2);
            foreach (var need in needs)
            {
                IEnumerable<PropertyInfo> list = need.GetType().GetProperties().Where(prop => (string)prop.GetValue(need, null) == "starter");
                foreach (var item in list)
                {
                    //This will give you the propertyName
                    Console.WriteLine(item.Name);
                }
            }
            Console.ReadLine();
        }
    }
    public class TeamNeeds
    {
        public string QB { get; set; }
        public string RB { get; set; }
        public string WR { get; set; }
        public string TE { get; set; }
    }
