    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="MyResourceDictionary.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>
    
    <Grid x:Name="Body">
        <ContentControl x:Name="Sample" ContentTemplate="{StaticResource MyResource1}"/>
    </Grid>
