    private async void preferenceChange(object sender, Preference.PreferenceChangeEventArgs e)
    {
         await System.Threading.Tasks.Task.Delay(100);
    
         List<string> sList = new List<string>();
         ICollection<string> selectedValues = mslp_dutyMarks.Values;
         foreach(string x in selectedValues)
              sList.Add(x);
    }
