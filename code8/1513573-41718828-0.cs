        private IEventAggregator iEventAggregator;
        public Drop(IEventAggregator ieventaggregator)
        {
            InitializeComponent();
            iEventAggregator = ieventaggregator;
            this.DataContext = this;
            var doc = XDocument.Load("C:\\Users\\srinivasaarudra.k\\Desktop\\students.xml");           
            var names = doc.Descendants("Name");
            foreach (var item in names)
            {
                droplist.Items.Add(item.Value);
            }
           
        }
        public string name;
        public string Naam
        {
            get { return name; }
            set { name = value;
            iEventAggregator.GetEvent<Itemselectedevent>().Publish(Naam);
            }
           
        }
        public string grade;
        public string Grade
        {
            get { return grade; }
            set
            {
                grade = value;
                iEventAggregator.GetEvent<gradeevent>().Publish(Grade);
            }
        }
        public string dept;
        public string Dept
        {
            get { return dept; }
            set
            {
                dept = value;
                iEventAggregator.GetEvent<deptevent>().Publish(Dept);
            }
        }
        public static string str;
        public static string Str
        {
            get { return str; }
            set {
                str = value;
               
                 }
        }
        private void droplist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          var sel = droplist.SelectedValue;
          Str=sel.ToString();
          XmlDocument doc2 = new XmlDocument();
          doc2.Load("C:\\Users\\srinivasaarudra.k\\Desktop\\students.xml");
          var details = doc2.DocumentElement.SelectNodes("/Students/StudentDetails");
          foreach (XmlNode node in details)
          {
              if (node.SelectSingleNode("Name").InnerText == Str)
              {
                  Naam = node.SelectSingleNode("Name").InnerText;
                  Grade = node.SelectSingleNode("Grade").InnerText;
                  Dept = node.SelectSingleNode("Department").InnerText;
              }
             
          }
        //  Details det = new Details();  
          Details dt = new Details(iEventAggregator);
              
        }
       
    }
     public class Itemselectedevent:Prism.Events.PubSubEvent<string>
        {
        }
     public class gradeevent : Prism.Events.PubSubEvent<string>
     {
     }
     public class deptevent : Prism.Events.PubSubEvent<string>
     {
     }
