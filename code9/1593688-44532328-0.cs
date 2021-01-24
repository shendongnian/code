            switch (day)
            {
                case "Monday":                   
                    ListViewMonday = new ListView(Activity);
                    MondayExerciseList = new List<Exercise>();                      
                    MondayAdapter = new Adapters.Exercise(Activity, MondayExerciseList);
                    ListViewMonday.Adapter = MondayAdapter;
                    layout.AddView(ListViewMonday);
                    ListViewMonday.ItemClick += ListViewMonday_ItemClick;
                    break;
                case "Tuesday":
                    ListViewTuesday = new ListView(Activity);
                    TuesdayExerciseList = new List<Exercise>();
                    TuesdayAdapter = new Adapters.Exercise(Activity, TuesdayExerciseList);
                    ListViewTuesday.Adapter = TuesdayAdapter;
                    layout.AddView(ListViewTuesday);
                    ListViewTuesday.ItemClick += ListViewTuesday_ItemClick;
                    break;
                case "Wednesday":
                    ListViewWednesday = new ListView(Activity);
                    WednesdayExerciseList = new List<Exercise>();
                    WednesdayAdapter = new Adapters.Exercise(Activity, WednesdayExerciseList);
                    ListViewWednesday.Adapter = WednesdayAdapter;
                    layout.AddView(ListViewWednesday);
                    ListViewWednesday.ItemClick += ListViewWednesday_ItemClick;
                    break;
            }
