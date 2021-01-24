    public class SpecimenViewModel
        {
            private Specimen specimen;
            private ObservableCollection<string> resultOptions = new ObservableCollection<string>();
    
            public SpecimenViewModel(Specimen specimen)
            {           
                resultOptions.Add("Select Note");
                resultOptions.Add("Select 1");
                resultOptions.Add("Select 2");
                resultOptions.Add("Select 3");
    
                this.specimen = specimen;
                RaisePropertyChanged("SelectedNote");
            }
    
    
            public Specimen Specimen
            {
                get
                {
                    return specimen;
                }
                set
                {
                    specimen = value;
                    RaisePropertyChanged("Specimen");
                }
            }
    
            public string SelectedNote
            {
                get
                {
                    if (specimen.ResultNote == null)
                        specimen.ResultNote = "Select Note";
                    return specimen.ResultNote;
                }
                set
                {
                    specimen.ResultNote = value;
                    RaisePropertyChanged();
                }
            }
    
            public ObservableCollection<string> ResultOptions
            {
                get { return resultOptions; }
                set
                {
                    resultOptions = value;
                    RaisePropertyChanged();
                }
            }
    
    
            }
