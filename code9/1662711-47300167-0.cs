    public class Model
    {
        public string StateBar { get; set; }
    }
     // In the form
    var states = new List<string> { "Alabama", "California" };
    combobox.DataSource = states;
    combobox.DataBindings.Add("SelectedValue", _model, "StateBar", true, DataSourceUpdateMode.OnPropertyChanged);
