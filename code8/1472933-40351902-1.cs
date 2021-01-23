    <TabControl x:Name="mainsTabControl"
                IsEnabled="True"
                IsSynchronizedWithCurrentItem="True"
                ItemsSource="{Binding Path=Mains}"
                SelectedItem="0"
                Visibility="Visible">
        <TabControl.ItemContainerStyle>
            <Style TargetType="{x:Type TabItem}">
                <Setter Property="IsSelected" Value="{Binding IsSelected}" />
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TabItem}">
                            <Border Background="{TemplateBinding Background}">
                                <ContentPresenter ContentSource="Header" />
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter Property="Background" Value="HotPink" />
                    </Trigger>
                </Style.Triggers>
            </Style>
        </TabControl.ItemContainerStyle>
        <TabControl.ItemTemplate>
            <DataTemplate DataType="{x:Type local:MainContentViewModel}">
                <Button Background="{x:Null}"
                        Command="{Binding SomeCommand}"
                        Content="{Binding Name}"
                        FocusVisualStyle="{x:Null}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate DataType="{x:Type local:MainContentViewModel}">
                <ItemsControl Margin="10"
                              VerticalAlignment="Top"
                              ItemsSource="{Binding Path=CustomItems}">
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <StackPanel Orientation="Vertical" />
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                    <ItemsControl.ItemTemplate>
                        <DataTemplate DataType="{x:Type local:CustomItem}">
                            <TextBlock Text="{Binding Name}" />
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
