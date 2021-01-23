            private void CalorieTracker_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime currentTimeStamp = new DateTime();
            using (var db = new GoalDataContext())
            {
                foreach (var datenow in db.Calculations)
                    currentTimeStamp = datenow.date;
            }
            DateTime currentNow = DateTime.Now;
            int changeDay = currentNow.Day;
            if (currentTimeStamp.Day != changeDay)
            {
                DataContextHelper.ResetItem();
            }
                 
            //other stuff's here
        }
