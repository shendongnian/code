    <TabControl HorizontalAlignment="Left" Height="175" VerticalAlignment="Top" Width="716" Margin="10,0,0,0">
        <TabItem Header="Class">
            <DataGrid 
                x:Name="ClassViewDataGrid" 
                ItemsSource="{Binding FilteredClassViewItems}" 
                AutoGenerateColumns="False"
                IsReadOnly="True"
                CanUserReorderColumns="True"
                CanUserResizeColumns="True"
                CanUserSortColumns="True"
                >
                <DataGrid.Columns>
                    <DataGridTextColumn 
                        Header="Class"
                        Binding="{Binding ClassName}" 
                        >
                        <DataGridTextColumn.HeaderTemplate>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="{Binding}" />
                                    <Button 
                                        Name="buttonClassViewClassFilter" 
                                        Margin="10,0,0,0"
                                        Command="{Binding DataContext.ShowFilterCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGrid}}}" 
                                        CommandParameter="{Binding Name, RelativeSource={RelativeSource Self}}"
                                        >
                                        <Button.ContentTemplate>
                                            <DataTemplate>
                                                <Image Source="/Images/filter.png" Width="10" Height="10" />
                                            </DataTemplate>
                                        </Button.ContentTemplate>
                                    </Button>
                                </StackPanel>
                            </DataTemplate>
                        </DataGridTextColumn.HeaderTemplate>
                    </DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
        </TabItem>
        <TabItem Header="Field">
            <DataGrid 
                x:Name="FielsdViewDataGrid" 
                ItemsSource="{Binding FilteredFieldViewItems}" 
                AutoGenerateColumns="False"
                IsReadOnly="True"
                CanUserReorderColumns="True"
                CanUserResizeColumns="True"
                CanUserSortColumns="True"
                >
                <DataGrid.Columns>
                    <DataGridTextColumn 
                        Header="Class"
                        Binding="{Binding ClassName}" 
                        >
                        <DataGridTextColumn.HeaderTemplate>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="{Binding}" />
                                    <Button 
                                        Name="buttonFieldViewClassFilter" 
                                        Margin="10,0,0,0"
                                        Command="{Binding DataContext.ShowFilterCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGrid}}}" 
                                        CommandParameter="{Binding Name, RelativeSource={RelativeSource Self}}"
                                        >
                                        <Button.ContentTemplate>
                                            <DataTemplate>
                                                <Image Source="/Images/filter.png" Width="10" Height="10" />
                                            </DataTemplate>
                                        </Button.ContentTemplate>
                                    </Button>
                                </StackPanel>
                            </DataTemplate>
                        </DataGridTextColumn.HeaderTemplate>
                    </DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
        </TabItem>
    </TabControl>
