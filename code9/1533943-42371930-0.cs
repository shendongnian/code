        private void findManagerForSelectedDate(String dateSelected)
        {
            dateSelected = dateTimePicker1.Value.ToShortDateString();
            List<string> tempUsersToAdd = new List<string>();
            List<String> managerNames = new List<String>();
            foreach(var item in managers)
            {
                foreach (var subitem in item)
                {
                    CalendarModel c = subitem;
                    Console.WriteLine(c.date);
                    c.name = new CultureInfo("en-US", false).TextInfo.ToTitleCase(c.name);
                    if (userSelection.Count > 0)
                    {
                        foreach (var addedUser in userSelection)
                        {
                            if (!addedUser.Contains(c.name))
                            {
                                tempUsersToAdd.Add(c.name);
                            }
                        }
                    }
                    else
                    {
                        tempUsersToAdd.Add(c.name);
                    }
                }
            }
            userSelection.AddRange(tempUsersToAdd);
