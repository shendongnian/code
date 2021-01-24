            namespace MedicalHubApplication
            {
            [Activity(Label = "TimeTable", NoHistory = true)]
            public class TimeTable : Activity
            {
           ClassInstance populateClass = new ClassInstance();
           UserInstance User = new UserInstance();
           GetConnectionClass Connect = new GetConnectionClass();
           Dictionary<string, List<ClassInstance>> dicMyMap;
        TextView DateHeaderTV;
        TextView NoteHeaderTV;
        ExpandableListViewAdapter myAdapater;
        ExpandableListView expandableListView;
        // Need Instance of List 
        NotesListViewAdapter myNoteAdapater;
        ListView NotesListView;
        ScrollView ScrollViewList;
        TextView StartMonday;
        Button SelectDateButton;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.TimeTable);
            expandableListView = FindViewById<ExpandableListView>(Resource.Id.ListViewExpanded);
            StartMonday = FindViewById<TextView>(Resource.Id.TextViewStartDateMonday);
            SelectDateButton = FindViewById<Button>(Resource.Id.SelectDateButton);
            NotesListView = FindViewById<ListView>(Resource.Id.NotesListView);
            DateHeaderTV = FindViewById<TextView>(Resource.Id.DateHeader);
            NoteHeaderTV = FindViewById<TextView>(Resource.Id.NoteHeader);
            ScrollViewList = FindViewById<ScrollView>(Resource.Id.ScrollView);
            // Populate User 
            User = JsonConvert.DeserializeObject<UserInstance>(Intent.GetStringExtra("User"));
            //Find Monday 
            DateTime TodaysDate = DateTime.Now;
            while (TodaysDate.DayOfWeek != DayOfWeek.Monday) TodaysDate = TodaysDate.AddDays(-1);
            
            try
            {
                var LoadingProgressDialog = ProgressDialog.Show(this, "Loading", "Loading", false);
                Thread LoadingThread = new Thread(() =>
                {
                    StartMonday.Text = "Week Commencing On " + TodaysDate.ToLongDateString();
                    SetData(TodaysDate);
                    FindNotesForWeek(TodaysDate, 7);
                    RunOnUiThread(() => LoadingProgressDialog.Hide());
                });
                LoadingThread.Start();
            }
            catch (Exception e)
            {
                var ErrorMessageDialog = ProgressDialog.Show(this, "Loading", e.ToString(), false);
            }
            
            SelectDateButton.Click += delegate
            {
                DateSelectOnClick();  
            }; 
        }
        
        private void DateSelectOnClick()
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime SelectedDate)
            {
                while (SelectedDate.DayOfWeek != DayOfWeek.Monday) SelectedDate = SelectedDate.AddDays(-1);
                                
                try
                {
                    var LoadingProgressDialog = ProgressDialog.Show(this, "Loading", "Loading", false);
                    Thread LoadingThread = new Thread(() =>
                    {
                        RunOnUiThread(() => StartMonday.Text = "Week Commencing On " + SelectedDate.ToLongDateString());
                        SetData(SelectedDate);
                        FindNotesForWeek(SelectedDate, 7);
                        RunOnUiThread(() => LoadingProgressDialog.Hide());
                    });
                    LoadingThread.Start();
                }
                catch (Exception e)
                {
                    var ErrorMessageDialog = ProgressDialog.Show(this, "Loading", e.ToString(), false);
                }
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
        private void SetData(DateTime date)
        {
            dicMyMap = null;
            dicMyMap = new Dictionary<string, List<ClassInstance>>();
            List<string> group = new List<string>();
            group.Add("Monday");
            group.Add("Tuesday");
            group.Add("Wednesday");
            group.Add("Thursday");
            group.Add("Friday");
            dicMyMap.Add(group[0], ListsPopulation(date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
            date = date.AddDays(+1);
            dicMyMap.Add(group[1], ListsPopulation(date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
            date = date.AddDays(+1);
            dicMyMap.Add(group[2], ListsPopulation(date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
            date = date.AddDays(+1);
            dicMyMap.Add(group[3], ListsPopulation(date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
            date = date.AddDays(+1);
            dicMyMap.Add(group[4], ListsPopulation(date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
            myAdapater = new ExpandableListViewAdapter(this, group, dicMyMap);
            RunOnUiThread(() => expandableListView.SetAdapter(myAdapater));
            
        }
        private List<ClassInstance> ListsPopulation(String date)
        {
            string sql = "SELECT * FROM lectures join groupConvert using (Groups) where StartDate = '" + date + "' AND Cohort = '" + User.Cohort + "' AND Year = '" + User.IntakeYear + "';";
            List<ClassInstance> Temp = new List<ClassInstance>();
            
            //Insert Header
            Temp.Add(new ClassInstance("Start Time", "End   Time", "Subject", "Location", "", ""));
            using (MySqlCommand cmd = new MySqlCommand(sql, Connect.GetConnection()))
            {
                 MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassInstance c = new ClassInstance(reader["StartTime"].ToString(), reader["EndTime"].ToString(), reader["Theme"].ToString(), reader["Location"].ToString(), reader["Essential"].ToString(), reader["Notes"].ToString());
                    Temp.Add(c);
                }
            }
            if (Temp.Count == 1)
            {
                Temp.Clear();
                Temp.Add(new ClassInstance("No Classes", "", "", "", "", ""));
            }
            return Temp;
        }
        private void FindNotesForWeek(DateTime StartDate, int DaysInMonth)
        {
            List<NotesInstance> WeekNotes = new List<NotesInstance>();
            WeekNotes.AddRange(FindNotesForDay(StartDate, StartDate.AddDays(+DaysInMonth)));
            if (WeekNotes.Count != 0)
            {
                RunOnUiThread(() => NoteHeaderTV.Visibility = ViewStates.Visible);
                RunOnUiThread(() => NotesListView.Visibility = ViewStates.Visible);
                RunOnUiThread(() => DateHeaderTV.Text = "Date:");
                myNoteAdapater = new NotesListViewAdapter(this, WeekNotes);
                RunOnUiThread(() => NotesListView.Adapter = myNoteAdapater);
            }
            else
            {
                RunOnUiThread(() => NoteHeaderTV.Visibility = ViewStates.Invisible);
                RunOnUiThread(() => NotesListView.Visibility = ViewStates.Invisible);
                RunOnUiThread(() => DateHeaderTV.Text = "No Notifications");
            }
            // Set up Adapter 
            myNoteAdapater = new NotesListViewAdapter(this, WeekNotes);
            RunOnUiThread(() => NotesListView.Adapter = myNoteAdapater);
        }
        private List<NotesInstance> FindNotesForDay(DateTime StartDate, DateTime EndDate)
        {
            string sql = "SELECT *  FROM Notes WHERE dates between '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "' AND yearGroup = '" + User.IntakeYear.ToString() + "';";
            List<NotesInstance> Temp = new List<NotesInstance>();
            using (MySqlCommand cmd = new MySqlCommand(sql, Connect.GetConnection()))
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NotesInstance c = new NotesInstance(reader.GetDateTime("dates").ToString("dd-MM-yyyy"), reader["Notes"].ToString());
                    Temp.Add(c);
                }
            }
            return Temp;
        }
    }
}
