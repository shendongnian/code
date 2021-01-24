    bindingSource = new BindingSource();
    bindingSource.DataSource = typeof(UsersBo); // to allow binding w/o actual object
    // statically bind the controls to the binding source
    UsernameTextEdit.DataBindings.Add("EditValue", bindingSource, "Username", true, DataSourceUpdateMode.OnPropertyChanged);
    LastNameTextEdit.DataBindings.Add("EditValue", bindingSource, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
    FirstNameTextEdit.DataBindings.Add("EditValue", bindingSource, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
