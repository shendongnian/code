    public class DataTemplateCollection : ObservableCollection<DataTemplate>
    {
    }
    <custom:CustomWizardControl>
        <custom:CustomWizardControl.WizardTemplateCollection>
            <custom:DataTemplateCollection>
                <DataTemplate>
                    <Rectangle></Rectangle>
                </DataTemplate>
                <DataTemplate>
                    <Rectangle></Rectangle>
                </DataTemplate>
                <DataTemplate>
                    <Rectangle></Rectangle>
                </DataTemplate>
            </custom:DataTemplateCollection>
        </custom:CustomWizardControl.WizardTemplateCollection>
    </custom:CustomWizardControl>
