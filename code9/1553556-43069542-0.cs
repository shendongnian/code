    public class CustomWizardControl : Control
    {
        public ObservableCollection<DataTemplate> WizardTemplateCollection
        {
            get { return (ObservableCollection<DataTemplate>)GetValue(WizardTemplateCollectionProperty); }
            set { SetValue(WizardTemplateCollectionProperty, value); }
        }
        ...
    }
