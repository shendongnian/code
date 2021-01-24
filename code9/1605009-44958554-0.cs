    public class Team
    {
        public string Name { get; set; }
        public string ManagerName => Manager.Name;
        public Manager manager { get; set; }
        public Team() { }
        public Team(string _name,Manager _mananger)
        {
            Name = _name;
            manager = _mananger;
        Lists.ListOfTeams.Add(this);
        }
    }
