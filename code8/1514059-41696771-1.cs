    <StackPanel>
        <StackPanel.Resources>
            <DataTemplate x:Key="textbox">
                <TextBox Text="edit me"/>
            </DataTemplate>
            <DataTemplate x:Key="textblock">
                <TextBlock Text="can't edit"/>
            </DataTemplate>
        </StackPanel.Resources>
        <CheckBox IsChecked="{Binding IsEditable}" Content="Editable"/>
        <ContentControl Content="{Binding}">
            <ContentControl.Style>
                <Style TargetType="{x:Type ContentControl}">
                    <Setter Property="ContentTemplate" Value="{StaticResource textblock}" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsEditable}" Value="true">
                            <Setter Property="ContentTemplate" Value="{StaticResource textbox}" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ContentControl.Style>
        </ContentControl>
    </StackPanel>
