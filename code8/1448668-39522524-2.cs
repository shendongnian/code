    IEnumerable<string> names = new [] { "English", "Photography" };
    foreach (string name in names)
    {
         // Build the property name
         string propertyName = String.Concat(name, "Picker");
 
         // Get Picker instance by locating the correct property
         object picker = this.GetType().GetProperty(propertyName).GetValue(this);
 
         // Get the SelectedColorText method from that instance
         MethodInfo pickerMethod = picker.GetType().GetMethod("SelectedColorText");
         // Call the method with the correct arguments and get the result
         string first = (string)pickerMethod.Invoke(picker, new object[] { 0, 1 });
         string last = (string)pickerMethod.Invoke(picker, new object[] { 3, 6 });
         string label = String.Concat(first, last);
         // Call UpdateSetting
         UpdateSetting(name, label);
    }
