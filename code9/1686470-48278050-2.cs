        public class ViewModel : ReactiveObject
        {
            private bool _allSelected;
    
            public bool AllSelected
            {
                get { return _allSelected; }
                set { this.RaiseAndSetIfChanged(ref _allSelected, value); }
            }
    
            public ViewModel()
            {
                Features = new ReactiveList<Feature>
                {
                    ChangeTrackingEnabled = true // this enabes few tricks
                };
    
                Features.ItemChanged.Where(x => x.PropertyName == nameof(Feature.Checked)).Subscribe(_ =>
                {
                    // any time item in the list is checked, select/deselect all
                    if (Features.All(x => x.Checked)) // feel free to filter out disabled features
                        AllSelected = true;
                    else
                        AllSelected = false;
                    // you can make AllSeleted nullable and make checkbox show "NotSpecified" state like in some installers, when not all, but some are selected
                });
    
                this.WhenAnyValue(x => x.AllSelected).Subscribe(x =>
                {
                    // each time someone checks AllFeatures checkbox, check/uncheck all
                    // x has the value of AllSelected
                    using (Features.SuppressChangeNotifications()) // to prevent setting AllSelected to false after checking every item
                        foreach (var feature in Features)
                        {
                            feature.Checked = x;
                        }
                });
    
    Features.Add(new Feature{Name="Feature 1", Enabled =  true, Checked = true}); // add all other features, maybe get them from database or from REST service, you name it
    
            }
    
            public ReactiveList<Feature> Features { get; set; }
        }
