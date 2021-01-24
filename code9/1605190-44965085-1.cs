        public Form1()
        {
            InitializeComponent();
            List<Activity> activities = new List<Activity>();
            activities.Add(new Activity(1, 2, "Mail client", 5));
            activities.Add(new Activity(2, 2, "Fix problem", 5));
            activities.Add(new Activity(3, 2, "Mail client for success", 10));
            activities.Add(new Activity(4, 2, "Mail client", 5));
            foreach(Activity a in activities)
            {
                a.DrawToForm(this);
            }
        } 
