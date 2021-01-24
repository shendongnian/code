    public class DataTemplateCollection : ObservableCollection<DataTemplate>
    {
    }
    <custom:CustomWizardControl>
        <custom:CustomWizardControl.WizardTemplateCollection>
            <DataTemplateCollection>
                <DataTemplate>
                    <Rectangle></Rectangle>
                </DataTemplate>
                <DataTemplate>
                    <Rectangle></Rectangle>
                </DataTemplate>
                <DataTemplate>
                    <Rectangle></Rectangle>
                </DataTemplate>
            </DataTemplateCollection>
        </custom:CustomWizardControl.WizardTemplateCollection>
    </custom:CustomWizardControl>
