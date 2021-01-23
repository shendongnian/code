    suggestComboBox.DataSource = new List<person>();
    suggestComboBox.DisplayMember = "Name";
    // then you have to set the PropertySelector like this:
    suggestComboBox.PropertySelector = collection => collection.Cast<person>      
    ().Select(p => p.Name);
    // the class Person looks something like this:
    class Person
    {
      public string Name { get; set; }
      public DateTime DateOfBirth { get; set; }
      public int Height { get; set; }
    }</person>
