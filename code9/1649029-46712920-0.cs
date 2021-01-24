         <ListView ItemsSource="{Binding Items}" Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="2" ScrollViewer.HorizontalScrollBarVisibility="Hidden" PreviewMouseWheel="OnPreviewMouseWheel" ScrollViewer.VerticalScrollBarVisibility="Hidden">
             <ListView.View>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="30" />
                        <RowDefinition Height="Auto" />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
    
                    <Label Grid.Row="0" Grid.Column="0" Content="{Binding Path=Items.Header}" />
                    <ContentControl Grid.Row="1" Grid.Column="0" Content="{Binding}" />
                </Grid>
           </ListView.View>
         </ListView>
