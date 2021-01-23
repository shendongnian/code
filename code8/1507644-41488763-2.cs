        public IEnumerable<DateTime> DateTimes()
        {
            using(DataContext dc = new DataContext("constring"))
            {
                return dc.ExecuteQuery<DateTime>("SELECT Time FROM dbo.Planner");
            }
        }
        public void Check()
        {
            foreach(var dateTime in DateTimes())
            {
                if(dateTime.Minute==DateTime.Now.Minute && dateTime.Hour ==  DateTime.Now.Hour)
                {
                    MessageBox.Show("Notification");
                }
            }
        }
