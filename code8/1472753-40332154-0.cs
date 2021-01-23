     txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
     txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
     var autoCompleteCollection = new AutoCompleteStringCollection();
     autoCompleteCollection.AddRange(DAL.GetMethod().ToArray());
     textbox.AutoCompleteCustomSource = autoCompleteCollection;
