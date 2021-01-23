    <ListView BindingGroup="{Binding Name}" ItemsSource="{Binding Source={StaticResource TestItems}}">
        <ListView.View>
            <GridView>
                <GridView.ColumnHeaderContainerStyle>
                    <Style TargetType="GridViewColumnHeader">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type GridViewColumnHeader}">
                                    <!-- Empty: ListViews header shows nothing -->
                                </ControlTemplate>
                            </Setter.Value>
                            </Setter>
                        </Style>
                    </GridView.ColumnHeaderContainerStyle>
                                <GridViewColumn DisplayMemberBinding="{Binding Parameter0}" Header="Par0" />
                <GridViewColumn DisplayMemberBinding="{Binding Parameter1}" Header="Par1" />
            </GridView>
        </ListView.View>
        <ListView.GroupStyle>
            <GroupStyle>
                <GroupStyle.HeaderTemplate>
                    <DataTemplate>
                        <Expander Margin="2">
                            <Expander.Header>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text=" # " />
                                    <TextBlock Text="{Binding Name}" />
                                </StackPanel>
                            </Expander.Header>
                            <StackPanel Orientation="Vertical">
                                <GridViewHeaderRowPresenter Margin="15,0,0,0"
                                                        Columns="{Binding Columns}"
                                                        DataContext="{Binding View, RelativeSource={RelativeSource FindAncestor, ListView, 1}}"
                                                        SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"
                                                        Visibility="Visible" />
                                <ItemsPresenter Margin="15,0,0,0" />
                            </StackPanel>
                        </Expander>
                    </DataTemplate>
                </GroupStyle.HeaderTemplate>
            </GroupStyle>
        </ListView.GroupStyle>
    </ListView>
