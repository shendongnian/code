    public class InstallViewModel
    {
        public Dictionary<MyFeatureEnum, Feature> Features { get; set; }
        public InstallViewModel()
        {
            // Generate the list of features
            Features = new Dictionary<MyFeatureEnum, Feature>();
            foreach (MyFeatureEnum f in Enum.GetValues(typeof(MyFeatureEnum)))
            {
                Features.Add(f, new Feature(f));
            }
        }
    }
----------
    <CheckBox IsChecked="{Binding Features[FEATURE1].Selected, Mode=TwoWay}" />
