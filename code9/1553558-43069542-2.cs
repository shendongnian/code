    public class CustomWizardControl : UIElement
    {
        public CustomWizardControl()
        {
            WizardTemplateCollection = new ObservableCollection<DataTemplate>();
        }
        public ObservableCollection<DataTemplate> WizardTemplateCollection
        {
            get { return (ObservableCollection<DataTemplate>)GetValue(WizardTemplateCollectionProperty); }
            set { SetValue(WizardTemplateCollectionProperty, value); }
        }
        public static readonly DependencyProperty WizardTemplateCollectionProperty =
            DependencyProperty.Register("WizardTemplateCollection", typeof(ObservableCollection<DataTemplate>), typeof(CustomWizardControl), new PropertyMetadata(null));
    }
----------
    <local:CustomWizardControl x:Name="ctrl">
        <local:CustomWizardControl.WizardTemplateCollection>
            <DataTemplate>
                <Rectangle></Rectangle>
            </DataTemplate>
            <DataTemplate>
                <Rectangle></Rectangle>
            </DataTemplate>
            <DataTemplate>
                <Rectangle></Rectangle>
            </DataTemplate>
        </local:CustomWizardControl.WizardTemplateCollection>
    </local:CustomWizardControl>
