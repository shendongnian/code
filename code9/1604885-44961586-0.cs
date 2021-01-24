    public class BuildingGroup
    {
        public int ID { get; set; }
        public string NameOfManager { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
    }
    public class Architect
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Building> BuildingsBeingWorkedOn { get; set; }
    }
    public class Building
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Architect> Architects { get; set; }
        public virtual ICollection<BuildingGroup> BuildingGroups { get; set; }
    }
