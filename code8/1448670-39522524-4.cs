    IEnumerable<string> names = new [] { "English", "Photography" };
    foreach (string name in names)
    {
         // Build the property name
         string propertyName = String.Concat(name, "Picker");
 
         // Get Picker instance by locating the correct property
         object picker = this.GetType().GetProperty(propertyName).GetValue(this);
 
         // Get the SelectedColorText value from that instance
         string colorText = (string) picker.GetType().GetProperty("SelectedColorText").GetValue(picker);
         string first = colorText.Substring(0, 1);
         string last = colorText.Substring(3, 6);
         string label = String.Concat(first, last);
         // Call UpdateSetting
         UpdateSetting(name, label);
    }
