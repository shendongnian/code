    <DataGrid ItemsSource="{Binding Model.Collection}">
        <DataGrid.Resources>
            <local:BindingProxy x:Key="VMProxy" Data="{Binding}" />
            <local:BindingProxy x:Key="DataGridProxy" Data="{Binding RelativeSource={RelativeSource Self}}" />
            <Style TargetType="DataGridCell">
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu>
                            <MenuItem Header="Open Details"
                                      Command="{Binding Data.OpenRowDetailsCommand, Source={StaticResource VMProxy}}" 
                                      CommandParameter="{Binding Data.SelectedIndex, Source={StaticResource DataGridProxy}}"/>
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.Resources>
