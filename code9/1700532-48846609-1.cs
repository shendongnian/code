    public class Family
    {
        public Family()
        {
            this.Members = new ObservableCollection<FamilyMember>();
        }
    
        public string Name { get; set; }
    
        public ObservableCollection<FamilyMember> Members { get; set; }
    }
    
    public class FamilyMember
    {
        public string Name { get; set; }
    
        public int Age { get; set; }
    }
