        bool UserIsJustLooking = false;
        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            UserIsJustLooking = true;
            dateTimePicker1.Tag = dateTimePicker1.Value;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (UserIsJustLooking)
            {
                // the user is just browsing the dates (ignore these value changed events because they aren't real)
            }
            else
            {
                Console.WriteLine("The value changed without opening, new value is " + dateTimePicker1.Value.ToString());
            }
        }
        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            UserIsJustLooking = false;
            if ((DateTime)dateTimePicker1.Tag == dateTimePicker1.Value)
            {
                // User did not really change the value
            }
            else
            {
                Console.WriteLine("User selected a new value: " + dateTimePicker1.Value);
            }
        }
 
