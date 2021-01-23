    <local:MyListView ItemsSource="{Binding Source={StaticResource items}}">
        <local:MyListView.ItemContainerStyle>
            <Style TargetType="{x:Type local:DesignerItem}">
                <Setter Property="IsEditing" Value="{Binding IsEditing,Mode=TwoWay}"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type local:DesignerItem}">
                            <DockPanel>
                                <ToggleButton DockPanel.Dock="Right" Margin="5" VerticalAlignment="Top" IsChecked="{Binding IsEditing,RelativeSource={RelativeSource TemplatedParent},Mode=TwoWay}" Content="Edit"/>
                                <!--Toolbar is something control related, rather than data related-->
                                <ToolBar x:Name="MyToolBar" DockPanel.Dock="Top" Visibility="Collapsed">
                                    <Button Content="Tool"/>
                                </ToolBar>
                                <ContentPresenter ContentSource="Content"/>
                            </DockPanel>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsEditing" Value="True">
                                    <Setter TargetName="MyToolBar" Property="Visibility" Value="Visible"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </local:MyListView.ItemContainerStyle>
        <local:MyListView.ItemTemplate>
            <DataTemplate>
                <Border Background="Red" Margin="5" Padding="5">
                    <TextBlock Text="Hello World"/>
                </Border>
            </DataTemplate>
        </local:MyListView.ItemTemplate>
    </local:MyListView>
