    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Skins/MainSkin.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>
    <Grid x:Name="LayoutRoot">
        <Button Command="{Binding EnableCommand}" Margin="115,75,120,160"/>
        <TextBox
               FontWeight="Bold"
               Foreground="Purple"
               Text="Test Text"
               IsEnabled ="{Binding IsEnabled}"
               VerticalAlignment="Center"
               HorizontalAlignment="Center"
               TextWrapping="Wrap" />
        </Grid>
    </Window>
