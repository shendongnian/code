    <ContentControl Content="{Binding Binding CurrentView}">
        <ContentControl.Resources>
            <DataTemplate DataType="local:DesignerViewModel">
                <local:DesignerUserControl />
            </DataTemplate>
            <DataTemplate DataType="local:TypeBViewModel">
                <local:TypeBUserControl />
            </DataTemplate>
        </ContentControl.Resources>
    </ContentControl>
