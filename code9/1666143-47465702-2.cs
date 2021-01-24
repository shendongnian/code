    <Page.DataContext>
        <local:MainViewModel></local:MainViewModel>
    </Page.DataContext>
    <ListView ItemsSource="{Binding Items}">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding MyText, Mode=OneWay}" FontSize="{Binding ItemFontSize, Mode=OneWay}" Width="{Binding TextWidth, Mode=OneWay}"  />
                    <Border Background="CornflowerBlue" Grid.Column="1" />
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
