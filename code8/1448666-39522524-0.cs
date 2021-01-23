    IEnumerable<string> names = new [] { "English", "Photography" };
    foreach (string name in names)
    {
         object picker = this.GetType().GetProperty(String.Concat(name, "Picker")).GetValue(this);
         MethodInfo pickerMethod = picker.GetType().GetMethod("SelectedColorText");
         string first = (string)pickerMethod.Invoke(picker, new object[] { 0, 1 });
         string last = (string)pickerMethod.Invoke(picker, new object[] { 3, 6 });
         string label = String.Concat(first, last);
         UpdateSetting(name, label);
    }
