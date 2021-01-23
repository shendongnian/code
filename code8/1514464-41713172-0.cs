    <ScrollViewer VerticalScrollBarVisibility="Visible" Grid.Row="1">
        <ListView Name="lvwMaster" ItemsSource="{x:Bind colAllCarMakers}" IsItemClickEnabled="True" ItemClick="lvwMaster_ItemClick">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="data:Manufacturer">
                    <UserControl>
                        <Border>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup>
                                    <VisualState x:Name="vsSmallPhone">
                                        <VisualState.StateTriggers>
                                            <AdaptiveTrigger MinWindowWidth="10" />
                                        </VisualState.StateTriggers>
                                        <VisualState.Setters>
                                            <Setter Target="lblManufacturerName.FontSize" Value="12" />
                                        </VisualState.Setters>
                                    </VisualState>
                                    <VisualState x:Name="vsPhone">
                                        <VisualState.StateTriggers>
                                            <AdaptiveTrigger MinWindowWidth="500" />
                                        </VisualState.StateTriggers>
                                        <VisualState.Setters>
                                            <Setter Target="lblManufacturerName.FontSize" Value="18" />
                                        </VisualState.Setters>
                                    </VisualState>
                                    <VisualState x:Name="vsTablet">
                                        <VisualState.StateTriggers>
                                            <AdaptiveTrigger MinWindowWidth="720" />
                                        </VisualState.StateTriggers>
                                        <VisualState.Setters>
                                            <Setter Target="lblManufacturerName.FontSize" Value="24" />
                                        </VisualState.Setters>
                                    </VisualState>
                                    <VisualState x:Name="vsDesktop">
                                        <VisualState.StateTriggers>
                                            <AdaptiveTrigger MinWindowWidth="1024" />
                                        </VisualState.StateTriggers>
                                        <VisualState.Setters>
                                            <Setter Target="lblManufacturerName.FontSize" Value="32" />
                                        </VisualState.Setters>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <TextBlock Name="lblManufacturerName" FontSize="32" Text="{x:Bind Name}" TextWrapping="Wrap" />
                        </Border>
                    </UserControl>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </ScrollViewer>
