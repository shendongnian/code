    for (int i = 0; i < 5; i++)
            {
                //add new elements to a collection
                week.Add(LayoutInflater.Inflate(Resource.Layout.DayElement, FindViewById<LinearLayout>(Resource.Id.linearLayoutTimeTable)));
                //define new LL
                LinearLayout lin = new LinearLayout(this);
                //assign the new LL the desired xml
                lin = FindViewById<LinearLayout>(Resource.Id.linearLayoutDay);
                //set its ID to smth fathomable
                lin.Id = i;
                
                //add 4 subjects of the predefined xml to every LL
                for (int j = 0; j < 4; j++)
                {
                    View subject = LayoutInflater.Inflate(Resource.Layout.SubjectEntry, FindViewById<LinearLayout>(i));
                }
            }   
