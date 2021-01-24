    private void TimerTick(object sender, EventArgs e)
    {
        // items is a list of string which contains strings to search for, such as "Joshua"
        ChangeStatus(items);
    }
    private void ChangeStatus(List<string> items)
    {
        foreach(string it in items)
        {
            if(!lv1.Items.Contains(it))
            {
                // Change the status of 'it' in ListView2 from Incomplete to Complete
                // Change only if status is 'Incomplete'. No point in changing if it's already 'Complete'.
            }
        }
    }
