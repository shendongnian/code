    public class MainPageViewModel
    {
        List<string> Profession1list=new List<string>() { "Lawyer", "Politician", "Other" };
        List<string> Profession2list = new List<string>() { "Lawyer2", "Politician2", "Other2" };
        public MainPageViewModel()
        {
            Profession1 = new Person(Profession1list);
            Profession2 = new Person(Profession2list);
        }
          private Person profession1;
        public Person Profession1
        {
            get { return profession1; }
            set { this.profession1 = value; }
        }
        private Person profession2;
        public Person Profession2
        {
            get { return profession2; }
            set { this.profession2 = value; }
        }
       ...
    }
    public class Person : INotifyPropertyChanged
    {
        public Person(List<string> Professionlist)
        {
            _professions = new List<string>();
            foreach(string item in Professionlist)
            {
                _professions.Add(item);
            }
            //_professions.Add("Lawyer");
            //_professions.Add("Politician");
            //_professions.Add("Other");
        }     
  
        private List<string> _professions;
        public List<string> Professions
        {
            get
            {
                return _professions;
            }
        }
      ...
      
    }
 
