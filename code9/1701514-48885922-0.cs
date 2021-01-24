    <ListBox  ItemsSource="{Binding CurrentRss.Channel.NewsItems}" SelectedItem="{Binding SelectedNewsItem}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="80"/>
                            <ColumnDefinition Width="*"/>
                        </Grid.ColumnDefinitions>
                        <Button Style="{StaticResource ImageButtonStyle}" Click="Button_Click" >
                            <Image Source="{Binding Image}"/>
                        </Button>
                        <TextBlock Grid.Column="1" Text="{Binding Title}"/>
                        <TextBlock x:Name="txtlink"  Text="{Binding Link}" Background="Black" Foreground="#FFD1DA0B"/>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>  
