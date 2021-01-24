     <ItemsControl ItemsSource="{Binding Items}"
                      VirtualizingStackPanel.IsVirtualizing="True"
                      VirtualizingStackPanel.VirtualizationMode="Recycling" Height="500">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Data}"  />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <VirtualizingStackPanel />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.Template>
                <ControlTemplate>
                    <Border >
                        <ScrollViewer VerticalScrollBarVisibility="Visible"
                                      CanContentScroll="True">
                            <ItemsPresenter />
                        </ScrollViewer>
                    </Border>
                </ControlTemplate>
            </ItemsControl.Template>
        </ItemsControl>
