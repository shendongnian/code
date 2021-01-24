    <TabControl (...)>
        <TabControl.Resources>
            <Style TargetType="{x:Type TabPanel}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SelectedIndex, RelativeSource={RelativeSource AncestorType=TabControl}}"
                                 Value="0">
                        <Setter Property="Visibility" Value="Collapsed" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </TabControl.Resources>
        (...)
    </TabControl>
