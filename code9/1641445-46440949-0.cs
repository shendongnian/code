    <DataGrid.RowHeaderTemplate>
        <DataTemplate>
            <Grid>
                <Expander Template="{StaticResource StretchyExpanderTemp}"
                          OverridesDefaultStyle="True"
                          Header=""
                          HorizontalAlignment="Right"
                          VerticalAlignment="Top"
                          Expanded="Expander_Expanded" Collapsed="Expander_Collapsed"
                          IsExpanded="{Binding DataContext.IsExpanded, RelativeSource={RelativeSource AncestorType=DataGridRowHeader}}" />
                
                <Canvas Background="BlueViolet" 
                        Width="5"
                        VerticalAlignment="Top"
                        HorizontalAlignment="Left" 
                        Height="5">
                    <TabControl Name="tcAA" 
                                TabStripPlacement="Left" 
                                Margin="20,18,0,0" 
                                Height="185"
                                Width="500"
                                VerticalAlignment="Top"
                                HorizontalAlignment="Left"
                                ItemsSource="{Binding DataContext.AAUDIT, RelativeSource={RelativeSource AncestorType=DataGridRowHeader}}" 
                                SelectedIndex="0" 
                                ClipToBounds="False"
                                Visibility="{Binding DataContext.IsExpanded, RelativeSource={RelativeSource AncestorType=DataGridRowHeader}, Converter={StaticResource bool2VisibilityConverter}}"
                                >
                        ...
                        <TabControl.ItemTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Text="{Binding DISPLAY_NAME}" />
                                </Grid>
                            </DataTemplate>
                        </TabControl.ItemTemplate>
                        <TabControl.ContentTemplate>
                            <DataTemplate>
                                ...
                            </DataTemplate>
                        </TabControl.ContentTemplate>
                    </TabControl>
                </Canvas>
            </Grid>
        </DataTemplate>
    </DataGrid.RowHeaderTemplate>
    <DataGrid.RowDetailsTemplate>
        <DataTemplate>
            <Grid Height="185" >
            </Grid>
        </DataTemplate>
    </DataGrid.RowDetailsTemplate>
