     xmlns:local="using:ImageTest.UWP"
        RequestedTheme="Light">
        <Application.Resources>
            <ResourceDictionary>
                <DataTemplate x:Key="MyDataTemplate">
                    <Grid >
                        <Grid.Resources>
                            <local:DateToStringConverter x:Key="MyConvert"/>
                        </Grid.Resources>
                        <Image Name="MyImage" Source="{Binding imageSource , Mode=OneWay, Converter={StaticResource MyConvert}}" />
                    </Grid>
                </DataTemplate>
            </ResourceDictionary>
        </Application.Resources>
   
