    <Application.Resources>
        <ResourceDictionary x:Name="ThemeDictionary">
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/AppStyles;component/Resources/Icons.xaml"/>
                <ResourceDictionary Source="pack://application:,,,/AppStyles;component/Resources/IconsNonShared.xaml"/>
                <!-- MahApps.Metro resource dictionaries. Make sure that all file names are Case Sensitive! -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml" />
                <!-- Accent and AppTheme setting -->
                <ResourceDictionary local:ResourceDictionaryExtensions.Name="Accents" Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml" />
                <ResourceDictionary local:ResourceDictionaryExtensions.Name="BaseTheme" Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseDark.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
