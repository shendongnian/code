    <Window>
        <Window.DataContext>
            <local:MainWindowViewModel/>
        </Window.DataContext>
        <Window.Resources>
            <ResourceDictionary>
                <local:MyConverter x:Key="MyConverter"/>
                <ControlTemplate x:Key="template">
                    <Grid>
                        <Grid Visibility="{Binding Status, Converter={StaticResource MyConverter}, ConverterParameter=1}">
                            <TextBox Text="1"/>
                        </Grid>
                        <Grid Visibility="{Binding Status, Converter={StaticResource MyConverter}, ConverterParameter=2}">
                            <TextBox Text="2"/>
                        </Grid>
                    </Grid>
                </ControlTemplate>
            </ResourceDictionary>
        </Window.Resources>
        <Grid>
            <Button Template="{StaticResource template}"/>
        </Grid>
    </Window>
