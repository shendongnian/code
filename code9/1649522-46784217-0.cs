    <StackPanel Background="Transparent" Margin="20,20,20,20">
        <Border BorderThickness="1" BorderBrush="Gray" Margin="0">
            <TreeView Name="treeView" BorderThickness="0" Background="Transparent" Height="400" ScrollViewer.HorizontalScrollBarVisibility="Disabled">
                <TreeView.ItemContainerStyle>
                    <Style TargetType="TreeViewItem">
                        <Setter Property="IsExpanded" Value="{Binding IsExpanded}" />
                    </Style>
                </TreeView.ItemContainerStyle>
                <TreeView.ItemTemplate>
                    <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="30"/>
                                <RowDefinition Height="*" />
                            </Grid.RowDefinitions>
                            <Border Grid.Column="0" Grid.Row="0">
                                <CheckBox IsChecked="{Binding IsChecked, Mode=TwoWay}" Click="CheckBox_Click" VerticalAlignment="Center">
                                    <TextBlock Text="{Binding Description}" Width="250" Margin="0,0,0,0"/>
                                </CheckBox>
                            </Border>
                            <Rectangle Grid.Row="1" Grid.Column="0"  HorizontalAlignment="Stretch" Fill="Gray" Height="1" Margin="-160"/>
                        </Grid>
                    </HierarchicalDataTemplate>
                </TreeView.ItemTemplate>
            </TreeView>
        </Border>
