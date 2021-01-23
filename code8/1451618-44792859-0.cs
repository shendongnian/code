    <Page.Resources>
        <ResourceDictionary>
            <ResourceDictionary.ThemeDictionaries>                
                <ResourceDictionary Source="Dictionary2.xaml" x:Key="Dark"/>
                <ResourceDictionary Source="Dictionary1.xaml" x:Key="Light"/>
            </ResourceDictionary.ThemeDictionaries>
        </ResourceDictionary>
    </Page.Resources>
    <StackPanel>
        <TextBlock Text="{ThemeResource txt}"/>
    </StackPanel>
