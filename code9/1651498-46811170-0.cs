    <UserControl ...>
        <UserControl.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="Global.xaml" />
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
        </UserControl.Resources>
        <UserControl.DataContext>
            <Binding Path="ApplicationVM" Source="{StaticResource Locator}" />
        </UserControl.DataContext>
        <Grid>
            
        </Grid>
    </UserControl>
