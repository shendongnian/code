    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- MyButtonStyle is in this dictionary -->
                <ResourceDictionary Source="ms appx:///Dictionaries/ButtonStyles.xaml"/>
            </ResourceDictionary.MergedDictionaries>
            <DataTemplate x:Key="MyDataTemplate">
                 <Grid>
                    <!-- Here is the button I want to apply the style to -->
                    <Button Style="{StaticResource MyButtonStyle}"/>
                </Grid>
            </DataTemplate>
        <ResourceDictionary>
    </UserControl.Resources>
